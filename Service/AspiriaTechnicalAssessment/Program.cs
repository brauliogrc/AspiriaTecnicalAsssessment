using AspiriaTechnicalAssessment.Core.Persistence;
using AspiriaTechnicalAssessment.Modules.Cors;
using AspiriaTechnicalAssessment.Modules.Injection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add DbContext using In-Memory Database.
var connectionString = builder.Configuration.GetConnectionString("DefaultInMemoryDatabase")
    ?? throw new InvalidOperationException("Connection string \"DefaultInMemoryDatabase\" not found");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(connectionString));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Dependency Injection
builder.Services.AddInjections(builder.Configuration);

// Cors
builder.Services.AddFeatureCors(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AspiriaApiPlicy");

app.Run();
