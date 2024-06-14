using Microsoft.Extensions.Options;
using ProjAndreVeiculosV3_Banco.Service;
using ProjAndreVeiculosV3_Banco.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjAndreVeiculosV3_Banco.Data;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProjAndreVeiculosV3_BancoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjAndreVeiculosV3_BancoContext") ?? throw new InvalidOperationException("Connection string 'ProjAndreVeiculosV3_BancoContext' not found.")));

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

builder.Services.AddSingleton<IConnectionFactory>(sp =>
{
    return new ConnectionFactory()
    {
        HostName = "localhost",   
        UserName = "guest",
        Password = "guest"
    };
});


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
