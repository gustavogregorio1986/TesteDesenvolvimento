using Microsoft.EntityFrameworkCore;
using TesteDesenvolvimento.Data.Context;
using TesteDesenvolvimento.Data.Repository;
using TesteDesenvolvimento.Data.Repository.Interface;
using TesteDesenvolvimento.Service.Service;
using TesteDesenvolvimento.Service.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAltitudeRepository, AltitudeRepository>();
builder.Services.AddScoped<IAltitudeService, AltitudeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
