using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CalculatorCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WebCalculator.Models;

namespace WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Calculator _calc;
        private string LastResultSessionKey = "lastResult";

        public HomeController(ILogger<HomeController> logger, Calculator calc)
        {
            _logger = logger;
            _calc = calc;
        }

        public IActionResult Index()
        {
            var lastResult = HttpContext.Session.GetString(LastResultSessionKey);

            if (lastResult == null)
                return View();
            else
                return View("Index", lastResult);
        }

        [HttpPost]
        public IActionResult Index(string evaluation)
        {
            var lastResult = HttpContext.Session.GetString(LastResultSessionKey);
            var result = _calc.Evaluate(evaluation, lastResult).Answer.ToString();

            HttpContext.Session.SetString(LastResultSessionKey, result);

            return View("Index",result);
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
