using Backend.Api.DependencyInjection;
using Backend.Business.DependencyInjection;
using Backend.DataAccess.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddApiServices()
    .AddBusinessServices()
    .AddDataAccessServices();

const string DevelopmentCorsPolicy = "AllowAll";

builder.Services.AddCors(o => o.AddPolicy(DevelopmentCorsPolicy, p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(DevelopmentCorsPolicy);
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
