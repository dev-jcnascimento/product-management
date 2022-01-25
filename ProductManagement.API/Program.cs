using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Api;
using Microsoft.OpenApi.Models;
using ProductManagement.Domain.Interface.IRepositories;
using ProductManagement.Domain.Interface.IRepositories.Base;
using ProductManagement.Domain.Interface.IServices;
using ProductManagement.Domain.Services;
using ProductManagement.Infra.Persistence;
using ProductManagement.Infra.Persistence.Repositories;
using ProductManagement.Infra.Persistence.Repositories.Base;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddDbContext<ProductManagementContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("PMContext")));
//builder.Services.AddScoped<ProductManagementContext>();

builder.Services.AddScoped<IRepositoryUser, RepositoryUser>();
builder.Services.AddScoped<IRepositoryProduct, RepositoryProduct>();
builder.Services.AddScoped<IRepositoryStock, RepositoryStock>();
builder.Services.AddScoped<IServiceStock, ServiceStock>();
builder.Services.AddScoped<IServiceProduct, ServiceProduct>();
builder.Services.AddScoped<IServiceUser, ServiceUser>();
builder.Services.AddScoped(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
 {
     {
           new OpenApiSecurityScheme
             {
                 Reference = new OpenApiReference
                 {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                 }
             },
             new string[] {}
     }
 });
});
builder.Services.AddCors();
// Add Authentication
#region Add Authentication

var key = Encoding.ASCII.GetBytes(Settings.Secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
