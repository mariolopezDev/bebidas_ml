using Microsoft.EntityFrameworkCore;
using Bebidas_ML.Data;
using Bebidas_ML.Services;
using Bebidas_ML.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<BebidasDbContext>(options =>
        options.UseInMemoryDatabase("BebidasDB"));
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBebidaService, BebidaService>();
builder.Services.AddScoped<IBebidaRepository, BebidaRepository>();

builder.Services.AddScoped<ITipoBebidaService, TipoBebidaService>();
builder.Services.AddScoped<ITipoBebidaRepository, TipoBebidaRepository>();


builder.Services.AddControllers();
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

app.UseRouting();

//app.UseAuthorization();

app.MapControllers();

app.Run();
