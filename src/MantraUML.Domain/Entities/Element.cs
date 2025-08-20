namespace MantraUML.Domain.Entities;

public class Element
{
    public Guid Id { get; set; }
    public string? Type { get; set; }
    public Guid DiagramId { get; set; }
}
