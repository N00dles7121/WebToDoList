using System.Text;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Tasks
{
    public class Index : PageModel
    {
        // private readonly ILogger<Index> _logger;

        // public Index(ILogger<Index> logger)
        // {
        //     _logger = logger;
        // }

        public List<TaskToDo> taskList = new List<TaskToDo>();

        public async Task OnGet()
        {
            var errorMessage = new StringBuilder();

            try
            {
                using ProgramContext context = new ProgramContext();

                taskList = await context.Tasks.Select(t => t).ToListAsync();
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessage.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
            }
        }
    }
}