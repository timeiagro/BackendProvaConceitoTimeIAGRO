using DesafioMiltec.Domain.Entities;
using DesafioMiltec.DTOs;
using System.Text.Json;

namespace DesafioMiltec.Application.Mappers
{
    public static class BookMapper
    {
        public static BookDto ToDto(Book book)
       => new()
       {
           Id = book.Id,
           Name = book.Name,
           Price = book.Price,
           Specifications = book.Specifications
               .ToDictionary(
                   x => x.Key,
                   x => ConvertJsonElement(x.Value)
               )
       };

        private static object? ConvertJsonElement(JsonElement element)
        {
            return element.ValueKind switch
            {
                JsonValueKind.String => element.GetString(),
                JsonValueKind.Number =>
                    element.TryGetInt32(out var i) ? i : element.GetDecimal(),
                JsonValueKind.Array =>
                    element.EnumerateArray()
                           .Select(ConvertJsonElement)
                           .ToList(),
                JsonValueKind.True => true,
                JsonValueKind.False => false,
                _ => null
            };
        }
    }
}
