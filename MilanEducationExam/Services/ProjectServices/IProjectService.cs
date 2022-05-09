using MilanEducationExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilanEducationExam.Services.ProjectServices
{
	public interface IProjectService
	{
		IEnumerable<ProjectEntity> GetAllProjects();
		IEnumerable<ProjectEntity> GetProject(ProjectEntity pr);
		Task<IEnumerable<ProjectEntity>> CreateProject(ProjectEntity pr);
		Task<IEnumerable<ProjectEntity>> UpdateProject(ProjectEntity pr);
		Task<IEnumerable<ProjectEntity>> DeleteProject(ProjectEntity pr);
	}
}
