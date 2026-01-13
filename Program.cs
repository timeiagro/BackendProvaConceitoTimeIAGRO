using CatalogoLivros.Api.Repositories;
using CatalogoLivros.Api.Services;


var builder = WebApplication.CreateBuilder(args);

// Adiciona Controllers
builder.Services.AddControllers();

// Injeção de dependência
builder.Services.AddSingleton<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

app.MapControllers();

app.Run();
public partial class Program { }