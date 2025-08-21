namespace MantraUML.Application.Dtos;

public class ClassResponse
{
    public Guid Id { get; set; }
    public string? Type { get; set; }
    public string? Label { get; set; }
    public List<AttributeResponse> Attributes { get; set; } = new List<AttributeResponse>();
    public PositionResponse?  Position { get; set; }
}
