using Microsoft.Extensions.Options;
using ProjAndreVeiculosV3_Banco.Service;
using ProjAndreVeiculosV3_Banco.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<BancoMongo>(
               builder.Configuration.GetSection(nameof(BancoMongo)));

builder.Services.AddSingleton<IBancoMongo>(sp =>
    sp.GetRequiredService<IOptions<BancoMongo>>().Value);

builder.Services.AddSingleton<BancoService>();

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
