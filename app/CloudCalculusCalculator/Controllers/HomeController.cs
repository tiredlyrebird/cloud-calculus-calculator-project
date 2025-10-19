using System.Diagnostics;
using CloudCalculusCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using MathNet.Symbolics;

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
            string input;
            if (model.Equation == null)
            {
                FormatForError(model, "No equation was recieved.");
                return View(model);
            }
            else
            {
                input = model.Equation;
            }

            try
            {
                Console.WriteLine(input); //For debugging
                MathUtils.ParsedMath math = MathUtils.FromJSON(input);
                model.Result = math.GetDisplaySolution();
            }
            catch (Exception ex)
            {
                FormatForError(model, $"Invalid equation \"{input}\".\nError: \"{ex.Message}\"");
                return View(model);
            }

            return View(model);
        }
        private static void FormatForError(EquationViewModel model, string message = "Error while evaluating equation.")
        {
            model.Result = message;
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
