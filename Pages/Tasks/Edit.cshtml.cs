using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

            taskToEdit = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task OnPost()
        {
            int.TryParse(Request.Query["id"], out int id);

            await EditTaskAsync(await context.Tasks.FirstOrDefaultAsync(t => t.Id == id));
        }

        private async Task EditTaskAsync(TaskToDo task)
        {
            if (string.IsNullOrWhiteSpace(Request.Form["body"]))
            {
                errorMessage = "Task can not be empty";
                return;
            }
            else
            {
                task.Body = Request.Form["body"];
                task.Description = Request.Form["description"];
                task.EditedOn = DateTime.UtcNow;
                await context.SaveChangesAsync();
                successMessage = "Task updated succesfully";
            }
        }
    }
}