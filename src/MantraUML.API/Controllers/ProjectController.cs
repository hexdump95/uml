using AutoMapper;

using MantraUML.Application.Common.Extensions;
using MantraUML.Application.Dtos;
using MantraUML.Application.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MantraUML.API.Controllers;

[Route("/api/v1/projects")]
[ApiController]
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
    [Authorize]
    public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetProjects()
    {
        string userId = User.GetUserId();
        return Ok(await _projectService.FindAllAsyncByUserId(userId));
    }

    [HttpGet("{projectId}/diagrams")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<DiagramResponse>>> GetDiagramsByProjectId(
        Guid projectId
    )
    {
        string userId = User.GetUserId();
        var diagrams = await _diagramService.FindAllAsyncByProjectIdAndUserId(projectId, userId);
        return Ok(diagrams);
    }
}
