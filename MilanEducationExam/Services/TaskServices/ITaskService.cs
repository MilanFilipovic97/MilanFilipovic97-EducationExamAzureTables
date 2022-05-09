using MilanEducationExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilanEducationExam.Services.TaskServices
{
	public interface ITaskService
	{
		IEnumerable<TaskEntity> GetAllTasks();
		IEnumerable<TaskEntity> GetTask(TaskEntity tsk);
		Task<IEnumerable<TaskEntity>> CreateTask(TaskEntity tsk);
		Task<IEnumerable<TaskEntity>> UpdateTask(TaskEntity tsk);
		Task<IEnumerable<TaskEntity>> DeleteTask(TaskEntity tsk);
	}
}
