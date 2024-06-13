using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProjAndreVeiculosV3_Banco.Service;
using ProjAndreVeiculosV3_Banco_MongoDB.Data;
using ProjAndreVeiculosV3_Banco_MongoDB.Utils;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProjAndreVeiculosV3_Banco_MongoDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjAndreVeiculosV3_Banco_MongoDBContext") ?? throw new InvalidOperationException("Connection string 'ProjAndreVeiculosV3_Banco_MongoDBContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<BancoMongoSettings>(
               builder.Configuration.GetSection(nameof(BancoMongoSettings)));

builder.Services.AddSingleton<IBancoMongoSettings>(sp =>
    sp.GetRequiredService<IOptions<BancoMongoSettings>>().Value);

builder.Services.AddSingleton<BancoMongoService>();

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
