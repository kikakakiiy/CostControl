using System.Linq;
using CostControl.Data;
using Microsoft.AspNetCore.Mvc;
using CostControl.Data;
using CostControl.Models;

namespace CostControl.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DashboardContext _context;

        public DashboardController(DashboardContext context)
        {
            _context = context;
        }

        public IActionResult Index(string projectName)
        {
            // Ambil semua project dari database
            var projects = _context.Projects.ToList();

            // Kalau user pilih project tertentu (bukan All), filter
            if (!string.IsNullOrEmpty(projectName) && projectName != "All")
            {
                projects = projects.Where(p => p.ProjectName == projectName).ToList();
            }

            // Kirim daftar nama project untuk dropdown
            ViewBag.ProjectNames = _context.Projects
                                           .Select(p => p.ProjectName)
                                           .Distinct()
                                           .ToList();

            ViewBag.SelectedProject = string.IsNullOrEmpty(projectName) ? "All" : projectName;

            return View(projects);
        }

    }
}
