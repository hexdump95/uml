namespace MantraUML.Domain.Entities;

public class Link : Element
{
    public PortElement? Target { get; set; }
    public PortElement? Source { get; set; }
    public string? Cardinalities { get; set; }
}
