using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class TaskToDo
    {
        public int Id { get; set; }
        public string Body { get; set; } = null!;
        public string? Description { get; set; }
    }
}