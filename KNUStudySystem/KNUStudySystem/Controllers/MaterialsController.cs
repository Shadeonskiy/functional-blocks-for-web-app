using KNUStudySystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KNUStudySystem.Controllers
{
    public class MaterialsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
