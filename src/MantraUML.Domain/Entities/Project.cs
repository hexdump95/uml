namespace MantraUML.Domain.Entities;

public class Project
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? UserId { get; set; }
    public IEnumerable<Diagram> Diagrams { get; set; } = new List<Diagram>();
}
