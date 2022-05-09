using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MilanEducationExam.Models;
using MilanEducationExam.Services.ProjectServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilanEducationExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly IProjectService _projectService;
        public ProjectController(IConfiguration configuration, IProjectService projectService)
        {
            config = configuration;
            _projectService = projectService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectEntity>>> Get()
        {
            var result = _projectService.GetAllProjects();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProjectEntity>>> Post([FromBody] ProjectEntity pe)
        {
            var result = await _projectService.CreateProject(pe);
            return Ok(result);

        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<ProjectEntity>>> Put([FromBody] ProjectEntity pe)
        {
            var result = await _projectService.UpdateProject(pe);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<ProjectEntity>>> Delete([FromBody] ProjectEntity pe)
        {
            var result = await _projectService.DeleteProject(pe);
            return Ok(result);

        }

    }
}
