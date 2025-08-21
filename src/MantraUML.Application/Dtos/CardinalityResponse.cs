using System.Text.Json.Serialization;

namespace MantraUML.Application.Dtos;

public class CardinalityResponse
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }
    [JsonPropertyName("offset")]
    public float Offset { get; set; }
    [JsonPropertyName("distance")]
    public float Distance { get; set; }
}
