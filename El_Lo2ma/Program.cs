
using El_Lo2ma_AccessModel.Contexts;
using El_Lo2ma_AccessModel.Repositories;
using El_Lo2ma_DomainModel.Interfaces;
using El_Lo2ma_DomainModel.Models;
using El_Lo2ma_Services.IServices.Auth;
using El_Lo2ma_Services.Services.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

#region UnitOfWork_DependencyInjection

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

#endregion


#region Services

builder.Services.AddScoped<IAuthServices, AuthServices>();

#endregion

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

builder.Services.AddCors();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
