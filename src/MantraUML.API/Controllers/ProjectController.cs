using MantraUML.Application.Common.Extensions;
using MantraUML.Application.Dtos;
using MantraUML.Application.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MantraUML.API.Controllers;

[Route("/api/v1/projects")]
[ApiController]
[Authorize]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly IDiagramService _diagramService;

    public ProjectController(IProjectService projectService, IDiagramService diagramService)
    {
        _projectService = projectService;
        _diagramService = diagramService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetProjects()
    {
        var userId = User.GetUserId();
        return Ok(await _projectService.FindAllAsyncByUserId(userId));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetProjectById(Guid id)
    {
        var userId = User.GetUserId();
        return Ok(await _projectService.FindOneAsyncByIdAndUserId(id, userId));
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<ProjectResponse>>> CreateProject([FromBody] ProjectRequest request)
    {
        var userId = User.GetUserId();
        var projectResponse = await _projectService.CreateProject(request, userId);
        return CreatedAtAction(nameof(GetProjectById), new { id = projectResponse.Id }, projectResponse);
    }

    [HttpGet("diagrams/{diagramId}")]
    public async Task<ActionResult<DiagramDetailResponse>> GetDiagramById(Guid diagramId)
    {
        var userId = User.GetUserId();
        return Ok(await _diagramService.FindOneAsyncByIdAndUserId(diagramId, userId));
    }

    [HttpGet("{projectId}/diagrams")]
    public async Task<ActionResult<IEnumerable<DiagramResponse>>> GetDiagramsByProjectId(Guid projectId)
    {
        var userId = User.GetUserId();
        var diagrams = await _diagramService.FindAllAsyncByProjectIdAndUserId(projectId, userId);
        return Ok(diagrams);
    }
}
