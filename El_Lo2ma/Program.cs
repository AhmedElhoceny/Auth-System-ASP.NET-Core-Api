
using El_Lo2ma.Constants;
using El_Lo2ma_AccessModel.Contexts;
using El_Lo2ma_AccessModel.Repositories;
using El_Lo2ma_DomainModel.DTOs;
using El_Lo2ma_DomainModel.DTOs.JWT;
using El_Lo2ma_DomainModel.Interfaces;
using El_Lo2ma_DomainModel.Models.Auth;
using El_Lo2ma_DomainModel.SwaggerFilter;
using El_Lo2ma_Services.IServices.Auth;
using El_Lo2ma_Services.IServices.General;
using El_Lo2ma_Services.Services.Auth;
using El_Lo2ma_Services.Services.General;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;
using UtilitiesManagement.Domain;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();
builder.Host.UseSerilog();

#region UnitOfWork_DependencyInjection

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

#endregion

#region JWTConfigration
//jwt configration
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.Configure<MailSettings>(config.GetSection("MailSettings"));

var jwtSettings = new JWT();
builder.Configuration.Bind(nameof(jwtSettings), jwtSettings);
builder.Services.AddSingleton(jwtSettings);

//to use jwt with authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer
    (o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey)),
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            //RequireExpirationTime = false, // Todo update
            ValidIssuer = jwtSettings.Issuer,
            ClockSkew = TimeSpan.Zero,

        };
    });
#endregion

#region Localization configuration
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


var supportedCultures = new[] { "ar", "en" };
var localizationOptions =
    new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);


#endregion

#region DependencyInjection
builder.Services.AddScoped<IAuthUserServices, AuthUserServices>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
#endregion


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(Modules.Auth, new OpenApiInfo()
    {
        Title = "Auth_Lo2ma",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer",

       },
        In = ParameterLocation.Header,
        Name= "Bearer",
      },
      new string[] { }
    }
    });
    c.SchemaFilter<swaggertest>();
});


//Context and Identity Configrations************************************
var Lo2maConnection = builder.Configuration.GetConnectionString("Lo2maConnection");
builder.Services.AddDbContext<Lo2maContext>(options =>
    options.UseSqlServer(Lo2maConnection));
builder.Services.AddIdentity<ApplicationUser,ApplicationRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    ////
    options.User.RequireUniqueEmail = false;
    //options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
})
    .AddEntityFrameworkStores<Lo2maContext>();
builder.Services.AddControllersWithViews().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//***********************************************************************
builder.Services.AddControllers().AddDataAnnotationsLocalization(options =>
{
    options.DataAnnotationLocalizerProvider = (type, factory) =>
        factory.Create(typeof(DataAnnotationValidation));
});


//***********************************************************************
builder.Services.AddCors();


try
{
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment() || app.Environment.IsProduction() || app.Environment.IsEnvironment("Local"))
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => { 
            c.SwaggerEndpoint($"/swagger/{Modules.Auth}/swagger.json", "Auth_Lo2ma v1");
        });
    }

    app.UseHttpsRedirection();

    app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().WithOrigins("*"));
    app.UseRequestLocalization(localizationOptions);

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
    Log.Information("Application Start....");

}
catch (Exception ex)
{
    Log.Fatal(ex,"Application Failed");
}
finally
{
    Log.CloseAndFlush();
}
