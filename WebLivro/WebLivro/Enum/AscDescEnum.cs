using System.Text.Json.Serialization;

namespace WebLivro.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AscDescEnum
{
    Asc,
    Desc
}