using API.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.ComponentModel;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddSwaggerGen(opts => {
    var Title = "Store API";
    var License = new OpenApiLicense() { 
    Name = Title,
    Url = new Uri("https://demolicense.com")
    };
    var contact = new OpenApiContact() { 
    Name = "Moath Tar",
    Email = "Thmrgb2@gmail.com"
    };
    opts.SwaggerDoc("v2", new OpenApiInfo() { Title = $"{Title} V2", Description = "Test API v2 :)", License = License, Version = "v2" });
    opts.SwaggerDoc("v1",new OpenApiInfo() { Title = $"{Title} V1",Description = "Test API v1 :)",License = License,Version = "v1" });

});
builder.Services.AddApiVersioning(opts => {
    opts.AssumeDefaultVersionWhenUnspecified = true;
    opts.DefaultApiVersion = new ApiVersion(2, 0);
    opts.ReportApiVersions = true;

});
builder.Services.AddVersionedApiExplorer(opts => {
    opts.GroupNameFormat = "'v'VVV";
    opts.SubstituteApiVersionInUrl = true;

});
builder.Services.AddAuthentication("Bearer").AddJwtBearer(opts => {
    opts.TokenValidationParameters = new TokenValidationParameters() {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetValue<string>("Authentication:Issuer"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Authentication:SecretKey"))),
        ValidAudience = builder.Configuration.GetValue<string>("Authentication:Audience"),
        ValidateLifetime = true
    };
});
builder.Services.AddAuthorization(opts => {
    opts.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opts.AddPolicy("Admin", policy => { policy.RequireClaim("Role", "Admin");});
    opts.AddPolicy("Moderator", policy => { policy.RequireClaim("Role", "Mod"); });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts => {
        opts.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
        opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
