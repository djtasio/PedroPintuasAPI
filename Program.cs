using API_PedroPinturas.Data;
using API_PedroPinturas.DataAccess.Servicios;
using API_PedroPinturas.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// """DATABASE AND DEPENDENCY INJECTION""" //
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<PedroPinturasDb>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<RespositoryAsync<Color>, RespositoryAsync<Color>>();
// """DATABASE AND DEPENDENCY INJECTION""" //

// Add services to the container.

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

//app.Urls.Add("http://+:5062"); // 5062 y todas las direcciones

app.Run();
