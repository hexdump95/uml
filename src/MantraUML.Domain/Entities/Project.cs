namespace MantraUML.Domain.Entities;

public class Project
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<Diagram> Diagrams { get; set; } = new();
}
