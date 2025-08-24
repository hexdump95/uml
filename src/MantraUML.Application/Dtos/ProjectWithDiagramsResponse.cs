namespace MantraUML.Application.Dtos;

public class ProjectWithDiagramsResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public List<DiagramResponse> Diagrams { get; set; } = new();
}
