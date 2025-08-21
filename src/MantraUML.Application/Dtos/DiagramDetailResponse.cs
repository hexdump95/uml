namespace MantraUML.Application.Dtos;

public class DiagramDetailResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? DiagramTypeName {get; set;}
    public List<ClassResponse> Classes { get; set; } = new List<ClassResponse>();
    public List<LinkResponse> Links { get; set; } = new List<LinkResponse>();
    public Guid? ProjectId { get; set; }
}
