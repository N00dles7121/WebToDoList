using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;
using WebApp.Data;

namespace WebApp.Pages.Tasks
{
    public class Index : PageModel
    {
        // private readonly ILogger<Index> _logger;

        // public Index(ILogger<Index> logger)
        // {
        //     _logger = logger;
        // }

        public List<TaskInfo> taskList = new List<TaskInfo>();

        public void OnGet()
        {
            try
            {
                using ProgramContext context = new ProgramContext();
                var tasks = from a in context.Tasks
                            select a;

                foreach (var t in tasks)
                {
                    taskList.Add(new TaskInfo
                    {
                        taskBody = t.Body,
                        taskId = Convert.ToString(t.Id),
                        taskDescription = t.Description,
                        taskCreatedOn = t.CreatedOn.ToLocalTime().ToString(),
                        taskEditedOn =
                                        (t.EditedOn is DateTime) ?
                                        Convert.ToDateTime(t.EditedOn)
                                        .ToLocalTime().ToString() : ""
                    });
                }
            }
            catch (System.Exception)
            {

            }
        }
    }

    public class TaskInfo
    {
        public string taskId = null!;
        public string taskBody = null!;
        public string? taskDescription;
        public string taskCreatedOn = null!;
        public string? taskEditedOn;
    }
}