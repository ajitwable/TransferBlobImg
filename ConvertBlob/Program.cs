using ConvertBlob.Context;
using ConvertBlob.InterFace;
using ConvertBlob.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("connString") ?? throw new InvalidOperationException("Connection string 'connString' is not found.");
var targetConnectionString = builder.Configuration.GetConnectionString("targetConnString") ?? throw new InvalidOperationException("Connection string 'targetConnectionString' is not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDbContext<TargetDbContext>(options =>
        options.UseMySql(targetConnectionString, ServerVersion.AutoDetect(targetConnectionString)));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBlobConverter, BlobConverterService>();

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
