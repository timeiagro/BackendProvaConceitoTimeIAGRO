using DesafioMiltec.Domain.Entities;
using DesafioMiltec.Domain.Interfaces;
using System.Text.Json;

namespace DesafioMiltec.Infrastructure.Repositories
{
    public sealed class JsonBookRepository : IBookRepository
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions;
        public JsonBookRepository(IConfiguration configuration)
        {
            var relativePath = configuration["BookJsonPath"]
        ?? throw new InvalidOperationException("BookJsonPath não configurado.");

            _filePath = Path.Combine(
                AppContext.BaseDirectory,
                relativePath);

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true
            };
        }

        public IReadOnlyCollection<Book> GetAll()
        {
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException(
                    $"Arquivo JSON não encontrado em '{_filePath}'.",
                    _filePath);
            }

            var json = File.ReadAllText(_filePath);

            var books = JsonSerializer.Deserialize<List<Book>>(
                json,
                _jsonOptions);

            return books ?? throw new InvalidOperationException(
                "Falha ao desserializar o arquivo JSON de livros.");
        }
    }
}
