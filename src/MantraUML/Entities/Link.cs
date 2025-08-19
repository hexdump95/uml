namespace MantraUML.Entities;

public class Link : Element
{
    public PortElement? Target { get; set; }
    public PortElement? Source { get; set; }
}
