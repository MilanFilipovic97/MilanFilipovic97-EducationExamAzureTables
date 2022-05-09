using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilanEducationExam.Models
{
    public class TaskEntity : TableEntity
    {
        public TaskEntity(string name, string description)
        {
            this.PartitionKey = name; this.RowKey = description;
        }
        public TaskEntity() { }

        public string Name { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public ProjectEntity Project { get; set; }
    }
}
