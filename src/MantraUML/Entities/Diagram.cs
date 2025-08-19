namespace MantraUML.Entities;

public class Diagram
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public IEnumerable<Element> Elements { get; set; } = new List<Element>();
    public Guid? DiagramTypeId { get; set; }
    public DiagramType? DiagramType { get; set; }
    public Guid? ProjectId { get; set; }
}
