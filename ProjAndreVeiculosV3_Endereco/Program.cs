using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProjAndreVeiculosV3_Endereco.Data;
using ProjAndreVeiculosV3_Endereco.Service;
using ProjAndreVeiculosV3_Endereco.Utils;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProjAndreVeiculosV3_EnderecoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjAndreVeiculosV3_EnderecoContext") ?? throw new InvalidOperationException("Connection string 'ProjAndreVeiculosV3_EnderecoContext' not found.")));

// Adiciona o serviço HttpClient
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ProjMongoDBAPIDataBaseSettings>(
               builder.Configuration.GetSection(nameof(ProjMongoDBAPIDataBaseSettings)));

builder.Services.AddSingleton<IProjMongoDBAPIDataBaseSettings>(sp =>
    sp.GetRequiredService<IOptions<ProjMongoDBAPIDataBaseSettings>>().Value);

builder.Services.AddSingleton<EnderecoService>();

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
