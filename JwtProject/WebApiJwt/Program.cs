using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false; // https �zerinden gelmeyen token'lar? kabul et
    opt.TokenValidationParameters = new TokenValidationParameters() // token do?rulama parametreleri
    {
        ValidIssuer = "https://localhost", // bu tokeni kim �retiyor
        ValidAudience = "https://localhost", // bu tokeni kim kullanabilir
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("jsonwebtokensuperapijsonwebtokensuperapi")), // bunla ?ifrele
        ValidateIssuerSigningKey = true, // imzay? do?rula,
        ValidateLifetime = true, // token s�resini do?rula
    };
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // kimlik do?rulama
app.UseAuthorization();

app.MapControllers();

app.Run();
