using System.Text.Json.Serialization;

namespace BackendProvaConceitoTimeIAGRO.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AscDescEnum
    {
        Asc,
        Desc
    }
}
