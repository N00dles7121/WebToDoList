using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
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

        public string errorMessage = "";
        public string successMessage = "";
        ProgramContext context = new ProgramContext();

        public void OnGet()
        {

        }

        public async Task OnPost()
        {
            if (string.IsNullOrWhiteSpace(Request.Form["body"]))
            {
                errorMessage = "Task can not be empty";
                return;
            }

            TaskToDo newTask = CreateNewTask();

            await context.Tasks.AddAsync(newTask);

            await context.SaveChangesAsync();

            successMessage = "Task created succesfully";
        }

        private TaskToDo CreateNewTask()
        {
            TaskToDo newTask = new TaskToDo()
            {
                Body = Request.Form["body"],
                Description = Request.Form["description"],
                CreatedOn = DateTime.UtcNow
            };

            return newTask;
        }
    }
}