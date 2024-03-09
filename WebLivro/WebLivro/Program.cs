using WebLivro.repository;
using WebLivros.Interfaces;
using WebLivros.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookModelService, BookModelService>();
builder.Services.AddScoped<IBookModelRepository, BookModelRepository>();
builder.Services.AddHttpClient<BookModelRepository>();
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
