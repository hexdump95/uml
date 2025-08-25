using AutoMapper;

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
    private readonly IDiagramTypeService _diagramTypeService;

    public ProjectController(IProjectService projectService, IDiagramService diagramService,
        IDiagramTypeService diagramTypeService)
    {
        _projectService = projectService;
        _diagramService = diagramService;
        _diagramTypeService = diagramTypeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetProjects()
    {
        var userId = User.GetUserId();
        return Ok(await _projectService.FindAllByUserId(userId));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectWithDiagramsResponse>> GetProjectById(Guid id)
    {
        var userId = User.GetUserId();
        var project = await _projectService.FindOneWithDiagramsByIdAndUserId(id, userId);
        return Ok(project);
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<ProjectResponse>>> CreateProject([FromBody] ProjectRequest request)
    {
        var userId = User.GetUserId();
        var projectResponse = await _projectService.CreateProject(request, userId);
        return Created("", projectResponse);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<IEnumerable<ProjectResponse>>> UpdateProjectName(Guid id,
        [FromBody] ProjectRequest request)
    {
        var userId = User.GetUserId();
        return Ok(await _projectService.UpdateProjectNameByIdAndUserId(id, userId, request));
    }

    [HttpGet("diagrams/diagram-types")]
    public async Task<ActionResult<List<DiagramTypeResponse>>> GetDiagramTypes()
    {
        return Ok(await _diagramTypeService.GetAllAsync());
    }

    [HttpGet("diagrams/{diagramId}")]
    public async Task<ActionResult<DiagramDetailResponse>> GetDiagramById(Guid diagramId)
    {
        var userId = User.GetUserId();
        return Ok(await _diagramService.FindOneByIdAndUserId(diagramId, userId));
    }

    [HttpPost("{projectId}/diagrams")]
    public async Task<ActionResult<DiagramResponse>> CreateDiagramByProjectId(Guid projectId,
        [FromBody] DiagramRequest request)
    {
        var userId = User.GetUserId();
        var diagram = await _diagramService.CreateDiagramByProjectId(projectId, userId, request);
        return Ok(diagram);
    }
}
