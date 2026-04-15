using Microsoft.AspNetCore.Mvc.Filters;
using ProductClientHub.API.Filters;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);

Batteries.Init();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(option => option.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddControllers();
builder.Services.AddOpenApi(); // Nativo do .NET 10

// 1. ADICIONE ESTA LINHA
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(option => option.Filters.Add(typeof(ExceptionFilter)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // O MapOpenApi cria o arquivo .json
    app.MapOpenApi();

    // 2. ADICIONE ESTAS DUAS LINHAS
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();