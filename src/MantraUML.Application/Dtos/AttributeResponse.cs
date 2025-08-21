using System.Text.Json.Serialization;

namespace MantraUML.Application.Dtos;

public class AttributeResponse
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    [JsonPropertyName("visibility")]
    public char? Visibility { get; set; }
}
