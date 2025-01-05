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
    public class Create : PageModel
    {
        // private readonly ILogger<Create> _logger;

        // public Create(ILogger<Create> logger)
        // {
        //     _logger = logger;
        // }

        public TaskInfo taskInfo = new TaskInfo();
        public string errorMessage = "";
        public string successMessage = "";

        public void OnGet()
        {

        }

        public void OnPost()
        {
            using ProgramContext context = new ProgramContext();

            TaskToDo newTask = new TaskToDo()
            {
                Body = Request.Form["body"],
                Description = Request.Form["description"]
            };

            if (newTask.Body.Length == 0 || newTask.Body == null)
            {
                errorMessage = "Task can not be empty";
                return;
            }

            context.Tasks.Add(newTask);
            context.SaveChanges();

            successMessage = "Task created succesfully";
        }
    }
}