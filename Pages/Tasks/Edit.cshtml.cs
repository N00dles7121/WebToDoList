using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Tasks
{
    public class Edit : PageModel
    {
        // private readonly ILogger<Edit> _logger;

        // public Edit(ILogger<Edit> logger)
        // {
        //     _logger = logger;
        // }

        public string errorMessage = "";
        public string successMessage = "";
        public TaskInfo taskInfo = new TaskInfo();
        ProgramContext context = new ProgramContext();

        public void OnGet()
        {
            int.TryParse(Request.Query["id"], out int id);

            var task = from t in context.Tasks
                       where t.Id == id
                       select t;

            foreach (var t in task)
            {
                taskInfo.taskBody = t.Body;
                taskInfo.taskDescription = t.Description;
                taskInfo.taskId = Convert.ToString(t.Id);
                taskInfo.taskCreatedOn = t.CreatedOn.ToString();
                taskInfo.taskEditedOn = t.EditedOn.ToString();
            }
        }

        public void OnPost()
        {
            int.TryParse(Request.Query["id"], out int id);

            var newTask = context.Tasks
                          .Where(t => t.Id == id)
                          .FirstOrDefault();

            if (newTask is TaskToDo)
            {
                newTask.Body = Request.Form["body"];
                newTask.Description = Request.Form["description"];
                newTask.EditedOn = DateTime.UtcNow;
                context.SaveChanges();
                successMessage = "Task updated succesfully";
                return;
            }
            else
            {
                errorMessage = "Task can not be empty";
                return;
            }
        }
    }
}