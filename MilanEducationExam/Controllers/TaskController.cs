using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MilanEducationExam.Models;
using MilanEducationExam.Services.TaskServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilanEducationExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly ITaskService _taskService;
        public TaskController(IConfiguration configuration, ITaskService taskService)
        {
            config = configuration;
            _taskService = taskService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskEntity>>> Get()
        {
            var result = _taskService.GetAllTasks();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<TaskEntity>>> Post([FromBody] TaskEntity tsk)
        {
            var result = await _taskService.CreateTask(tsk);
            return Ok(result);

        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<TaskEntity>>> Put([FromBody] TaskEntity tsk)
        {
            var result = await _taskService.UpdateTask(tsk);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<TaskEntity>>> Delete([FromBody] TaskEntity tsk)
        {
            var result = await _taskService.DeleteTask(tsk);
            return Ok(result);

        }

    }
}
