using Hamurabi.Core.Interfaces;
using Hamurabi.Core.Repositories;
using Hamurabi.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionar suporte a Controllers
builder.Services.AddControllers();

// Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar caminho do arquivo books.json
var booksFilePath = Path.Combine(builder.Environment.ContentRootPath, "..", "books.json");

// Registrar dependências (Injeção de Dependência)
builder.Services.AddSingleton<IBookRepository>(new BookRepository(booksFilePath));
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// Configurar o pipeline HTTP - SEMPRE habilitar Swagger (não só em Development)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catálogo de Livros API v1");
    c.RoutePrefix = string.Empty;
});

app.UseAuthorization();

app.MapControllers();

app.Run();