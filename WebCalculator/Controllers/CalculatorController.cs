using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebCalculator.Models;

namespace WebCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Calculator _calc;
        private string LastResultSessionKey = "lastResult";
        private string UserNameSessionKey = "username";

        public CalculatorController(ILogger<HomeController> logger, Calculator calc)
        {
            _logger = logger;
            _calc = calc;
        }

        public IActionResult Index()
        {
            var lastResult = HttpContext.Session.GetString(LastResultSessionKey);
            var username = HttpContext.Session.GetString(UserNameSessionKey);

            var vm = new SessionData
            {
                UserName = username,
                LastResult = lastResult
            };

            return View("Index", vm);
        }

        [HttpPost]
        public IActionResult Index(string evaluation)
        {
            var lastResult = HttpContext.Session.GetString(LastResultSessionKey);
            var result = _calc.Evaluate(evaluation, lastResult).Answer.ToString();
            HttpContext.Session.SetString(LastResultSessionKey, result);

            var username = HttpContext.Session.GetString(UserNameSessionKey);

            var vm = new SessionData
            {
                UserName = username,
                LastResult = result
            };

            return View("Index", vm);
        }
    }
}
