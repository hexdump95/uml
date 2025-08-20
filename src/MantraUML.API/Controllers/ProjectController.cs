using MantraUML.Application.Interfaces;
using MantraUML.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace MantraUML.API.Controllers;

[Route("/api/v1/projects")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> Index()
    {
        return Ok(await _projectService.FindAllAsync());
    }
}
