using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Configuration;
using MilanEducationExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilanEducationExam.Services.ProjectServices
{
	public class ProjectService : IProjectService
	{
		private readonly IConfiguration config;
		public ProjectService(IConfiguration config)
		{
			this.config = config;
		}

		public async Task<IEnumerable<ProjectEntity>> CreateProject(ProjectEntity pr)
		{
			var table = GetTableClientAsync();
			ProjectEntity ProjectEntity = new ProjectEntity(pr.Name, pr.Code);
			ProjectEntity.Name = pr.Name;
			ProjectEntity.Code = pr.Code;
			ProjectEntity.ProjectId = pr.ProjectId;
			ProjectEntity.tasks = pr.tasks;
			var query = new TableQuery<ProjectEntity>();
			TableOperation insertOperation = TableOperation.Insert(ProjectEntity);


			await table.ExecuteAsync(insertOperation);
			var result = table.ExecuteQuery(query);
			return result.ToList();
		}

		public async Task<IEnumerable<ProjectEntity>> DeleteProject(ProjectEntity pr)
		{
			var table = GetTableClientAsync();
			ProjectEntity ProjectEntity = new ProjectEntity(pr.Name, pr.Code);
			ProjectEntity.Name = pr.Name;
			ProjectEntity.Code = pr.Code;
			ProjectEntity.ProjectId = pr.ProjectId;
			ProjectEntity.tasks = pr.tasks;
			ProjectEntity.ETag = "*"; 
			var query = new TableQuery<ProjectEntity>();
			TableOperation insertOperation = TableOperation.Delete(ProjectEntity);
			await table.ExecuteAsync(insertOperation);
			var result = table.ExecuteQuery(query);
			return result.ToList();
		}

		public IEnumerable<ProjectEntity> GetAllProjects()
		{
			var table = GetTableClientAsync();
			var query = new TableQuery<ProjectEntity>();
			var result = table.ExecuteQuery(query);
			return result.ToList();
		}
		public IEnumerable<ProjectEntity> GetProject(ProjectEntity pr)
		{
			var table = GetTableClientAsync();
			var condition = TableQuery.GenerateFilterCondition("Name", QueryComparisons.Equal, pr.Name);
			var query = new TableQuery<ProjectEntity>().Where(condition);
			var result = table.ExecuteQuery(query);
			return result.ToList();
		}

		public async Task<IEnumerable<ProjectEntity>> UpdateProject(ProjectEntity pr)
		{
			var table = GetTableClientAsync();
			ProjectEntity ProjectEntity = new ProjectEntity(pr.Name, pr.Code);
			ProjectEntity.Name = pr.Name;
			ProjectEntity.Code = pr.Code;
			ProjectEntity.ProjectId = pr.ProjectId;
			ProjectEntity.tasks = pr.tasks;
			var query = new TableQuery<ProjectEntity>();
			TableOperation insertOperation = TableOperation.InsertOrMerge(ProjectEntity);
			await table.ExecuteAsync(insertOperation);
			var result = table.ExecuteQuery(query);
			return result.ToList();
		}

        private CloudTable GetTableClientAsync()
		{
			string tableConnection = config.GetValue<string>("ConnectionStrings:MyAzureTable");
			var account = CloudStorageAccount.Parse(tableConnection);
			var client = account.CreateCloudTableClient();

			var table = client.GetTableReference("Project");
			table.CreateIfNotExistsAsync();
			return table;
		}
	}
}
