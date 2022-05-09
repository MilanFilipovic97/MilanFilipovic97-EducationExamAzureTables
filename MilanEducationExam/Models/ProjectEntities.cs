using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilanEducationExam.Models
{
    public class ProjectEntity : TableEntity
    {
        public ProjectEntity(string name, string code)
        {
            this.PartitionKey = name; this.RowKey = code;
        }
        public ProjectEntity() { }

        public string Name { get; set; }
        public string Code { get; set; }
        public int ProjectId { get; set; }
        public List<TaskEntity> tasks { get; set; }
    }
}
