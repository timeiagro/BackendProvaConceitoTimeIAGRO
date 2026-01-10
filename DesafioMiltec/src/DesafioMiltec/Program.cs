using DesafioMiltec.Application.Services;
using DesafioMiltec.Application.Sorting;
using DesafioMiltec.Domain.Interfaces;
using DesafioMiltec.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SupportNonNullableReferenceTypes();
});

// Repositories
builder.Services.AddScoped<IBookRepository, JsonBookRepository>();

// Domain services
builder.Services.AddScoped<ICalculateShipping, CalculateShippingService>();

// Application services
builder.Services.AddScoped<BookService>();

// Sorting
builder.Services.AddScoped<PriceSortAsc>();
builder.Services.AddScoped<PriceSortDesc>();
builder.Services.AddScoped<NoSort>();

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
