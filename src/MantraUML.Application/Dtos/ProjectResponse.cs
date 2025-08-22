namespace MantraUML.Application.Dtos;

public class ProjectResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public bool HasDiagrams { get; set; }
    public DateTime UpdatedAt { get; set; }
}
