
using El_Lo2ma_AccessModel.Contexts;
using El_Lo2ma_DomainModel.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

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
builder.Services.AddIdentity<ApplicationUser,IdentityRole<int>>()
    .AddEntityFrameworkStores<Lo2maContext>();
//***********************************************************************


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
