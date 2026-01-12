using BookCatalogApi.Repository;
using BookCatalogApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new()
    {
        Title = "Book Catalog API",
        Version = "v1",
        Description = "API para busca de livros em catálogo JSON"
    });
});

var jsonFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "books.json");
builder.Services.AddSingleton<IBookRepository>(new JsonBookRepository(jsonFilePath));
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
