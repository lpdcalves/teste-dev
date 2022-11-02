using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using TesteDev.Models;
using Microsoft.Extensions.DependencyInjection;
using TesteDev.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TesteDevContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TesteDevContext") ?? throw new InvalidOperationException("Connection string 'TesteDevContext' not found.")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "UPD8 Teste Desenvolvedor .NET - Luiz P.C. Alves",
        Description = "Aplicação Web desenvolvida com ASP.NET MVC para o teste de desenvolvedor .NET da UPD8. Feito por Luiz P.C. Alves.",
    });
});

builder.Services.AddCors(options => options.AddPolicy(name: "TesteDevPolicy",
    policy =>
    {
        //policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }));

var app = builder.Build();

// Adding Swagger middleware only if in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("TesteDevPolicy");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
