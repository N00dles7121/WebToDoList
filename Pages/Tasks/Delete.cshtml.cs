using System.Text;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
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
        private readonly ProgramContext _context;

        public Delete(ProgramContext context)
        {
            _context = context;
        }

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
                var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
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