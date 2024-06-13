using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjAndreVeiculosV3_Dependente.Data;
using ProjAndreVeiculosV3_Dependente.Service;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProjAndreVeiculosV3_DependenteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjAndreVeiculosV3_DependenteContext") ?? throw new InvalidOperationException("Connection string 'ProjAndreVeiculosV3_DependenteContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DependenteService>();

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
