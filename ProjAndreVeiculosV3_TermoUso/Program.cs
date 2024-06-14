using Microsoft.Extensions.Options;
using ProjAndreVeiculosV3_TermoUso.Service;
using ProjAndreVeiculosV3_TermoUso.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<TermoUsoMongo>(
               builder.Configuration.GetSection(nameof(TermoUsoMongo)));

builder.Services.AddSingleton<ITermoUsoMongo>(sp =>
    sp.GetRequiredService<IOptions<TermoUsoMongo>>().Value);

builder.Services.AddSingleton<TermoUsoService>();
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
