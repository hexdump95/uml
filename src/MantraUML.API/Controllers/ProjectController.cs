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

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<ProjectResponse>>> Index()
    {
        string userId = User.GetUserId();
        return Ok(await _projectService.FindAllAsyncByUserId(userId));
    }
}
