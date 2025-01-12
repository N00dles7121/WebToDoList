using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using WebApp.Data;

namespace WebApp.Pages.Tasks
{
    public class Delete : PageModel
    {
        // private readonly ILogger<Delete> _logger;

        // public Delete(ILogger<Delete> logger)
        // {
        //     _logger = logger;
        // }

        StringBuilder errorMessage = new StringBuilder();
        ProgramContext context = new ProgramContext();

        public async Task OnGet()
        {
            int.TryParse(Request.Query["id"], out int id);

            await DeleteTask(id);

            Response.Redirect("/Tasks/Index");
        }

        private async Task DeleteTask(int id)
        {
            try
            {
                var task = context.Tasks.FirstOrDefault(t => t.Id == id);

                context.Tasks.Remove(task);
                await context.SaveChangesAsync();
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