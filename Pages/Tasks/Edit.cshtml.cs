using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
        public TaskToDo taskToEdit = new TaskToDo();
        ProgramContext context = new ProgramContext();

        public async Task OnGet()
        {
            int.TryParse(Request.Query["id"], out int id);

            var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            taskToEdit = task;
        }

        public async Task OnPost()
        {
            int.TryParse(Request.Query["id"], out int id);

            var newTask = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (string.IsNullOrWhiteSpace(Request.Form["body"]))
            {
                errorMessage = "Task can not be empty";
                return;
            }
            else
            {
                newTask.Body = Request.Form["body"];
                newTask.Description = Request.Form["description"];
                newTask.EditedOn = DateTime.UtcNow;
                await context.SaveChangesAsync();
                successMessage = "Task updated succesfully";
                return;
            }
        }
    }
}