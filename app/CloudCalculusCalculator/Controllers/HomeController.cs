using System.Diagnostics;
using CloudCalculusCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudCalculusCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index() //On load
        {
            return View(new EquationViewModel()); //Start with a new EquationViewModel object
        }
        [HttpPost]
        public IActionResult Index(EquationViewModel model)
        {
            string equation = model.Equation != null ? model.Equation : "";
            model.Result = equation; //simply output the equation received for now
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
