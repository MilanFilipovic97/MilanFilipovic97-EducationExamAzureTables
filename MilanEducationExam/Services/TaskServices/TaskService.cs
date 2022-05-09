using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Configuration;
using MilanEducationExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilanEducationExam.Services.TaskServices
{
	public class TaskService : ITaskService
	{
		private readonly IConfiguration config;
		public TaskService(IConfiguration config)
		{
			this.config = config;
		}

		public async Task<IEnumerable<TaskEntity>> CreateTask(TaskEntity tsk)
		{
			var table = GetTableClientAsync();
			TaskEntity TaskEntity = new TaskEntity(tsk.Name, tsk.Description);
			TaskEntity.Name = tsk.Name;
			TaskEntity.Description = tsk.Description;
			TaskEntity.ProjectId = tsk.ProjectId;
			TaskEntity.Project = tsk.Project;

			var query = new TableQuery<TaskEntity>();
			TableOperation insertOperation = TableOperation.Insert(TaskEntity);


			await table.ExecuteAsync(insertOperation);
			var result = table.ExecuteQuery(query);
			return result.ToList();
		}

		public async Task<IEnumerable<TaskEntity>> DeleteTask(TaskEntity tsk)
		{
			var table = GetTableClientAsync();
			TaskEntity TaskEntity = new TaskEntity(tsk.Name, tsk.Description);
			TaskEntity.Name = tsk.Name;
			TaskEntity.Description = tsk.Description;
			TaskEntity.ProjectId = tsk.ProjectId;
			TaskEntity.Project = tsk.Project;
			TaskEntity.ETag = "*"; 
			var query = new TableQuery<TaskEntity>();
			TableOperation insertOperation = TableOperation.Delete(TaskEntity);
			await table.ExecuteAsync(insertOperation);
			var result = table.ExecuteQuery(query);
			return result.ToList();
		}

		public IEnumerable<TaskEntity> GetAllTasks()
		{
			var table = GetTableClientAsync();
			var query = new TableQuery<TaskEntity>();
			var result = table.ExecuteQuery(query);
			return result.ToList();
		}

		public IEnumerable<TaskEntity> GetTask(TaskEntity tsk)
		{
			var table = GetTableClientAsync();
			var condition = TableQuery.GenerateFilterCondition("Name", QueryComparisons.Equal, tsk.Name);
			var query = new TableQuery<TaskEntity>().Where(condition);
			var result = table.ExecuteQuery(query);
			return result.ToList();
		}

		public async Task<IEnumerable<TaskEntity>> UpdateTask(TaskEntity tsk)
		{
			var table = GetTableClientAsync();
			TaskEntity TaskEntity = new TaskEntity(tsk.Name, tsk.Description);
			TaskEntity.Name = tsk.Name;
			TaskEntity.Description = tsk.Description;
			TaskEntity.ProjectId = tsk.ProjectId;
			TaskEntity.Project = tsk.Project;
			var query = new TableQuery<TaskEntity>();
			TableOperation insertOperation = TableOperation.InsertOrMerge(TaskEntity);
			await table.ExecuteAsync(insertOperation);
			var result = table.ExecuteQuery(query);
			return result.ToList();
		}
		private CloudTable GetTableClientAsync()
		{
			string tableConnection = config.GetValue<string>("ConnectionStrings:MyAzureTable");
			var account = CloudStorageAccount.Parse(tableConnection);
			var client = account.CreateCloudTableClient();

			var table = client.GetTableReference("Task");
			table.CreateIfNotExistsAsync();
			return table;
		}
	}
}
