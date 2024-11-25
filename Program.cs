using Microsoft.EntityFrameworkCore;
using SkillProfiCRM.Data;  // Замените на ваше пространство имен

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Подключаем базу данных SQLite
builder.Services.AddDbContext<SkillProfiContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SkillProfiDatabase")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
