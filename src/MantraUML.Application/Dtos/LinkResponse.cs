using MantraUML.Domain.Entities;

namespace MantraUML.Application.Dtos;

public class LinkResponse
{
    public Guid Id { get; set; }
    public string? Type { get; set; }
    public PortElement? Target { get; set; }
    public PortElement? Source { get; set; }
    public List<CardinalityResponse> Cardinalities { get; set; } = new List<CardinalityResponse>();
}
