using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HighSkill.API.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Получаем строку подключения
var connectionString = builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"] 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found");

// Регистрируем DbContext
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(connectionString));

// Добавляем сервисы
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Конфигурируем pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();