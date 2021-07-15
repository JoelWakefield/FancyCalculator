using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SessionOnSession;
using WebCalculator.Models;

namespace WebCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Calculator _calc;
        private string LastResultSessionKey = "lastResult";
        private string UserNameSessionKey = "username";
        private string HistorySessionKey = "history";

        public CalculatorController(ILogger<HomeController> logger, Calculator calc)
        {
            _logger = logger;
            _calc = calc;
        }

        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString(UserNameSessionKey);
            var lastResult = HttpContext.Session.GetString(LastResultSessionKey);

            var vm = new SessionData
            {
                UserName = username,
                LastResult = lastResult
            };

            return View("Index", vm);
        }

        [HttpPost]
        public IActionResult Index(string input)
        {
            var username = HttpContext.Session.GetString(UserNameSessionKey);
            var lastResult = HttpContext.Session.GetString(LastResultSessionKey);

            var evaluation = _calc.Evaluate(input, lastResult);
            
            if (String.IsNullOrWhiteSpace(evaluation.ErrorMessage))
            {
                lastResult = evaluation.Answer.ToString();
                HttpContext.Session.SetString(LastResultSessionKey, lastResult);

                EvaluationHistory history = HttpContext.Session.Get<EvaluationHistory>(HistorySessionKey);

                if (history == null)
                    history = new EvaluationHistory();
                history.Evaluations.Add(evaluation);

                HttpContext.Session.Set(HistorySessionKey, history);
            }

            var vm = new SessionData
            {
                UserName = username,
                LastResult = lastResult,
                Error = evaluation.ErrorMessage
            };

            return View("Index", vm);
        }

        public IActionResult History()
        {
            var history = HttpContext.Session.Get<EvaluationHistory>(HistorySessionKey);
            if (history == null)
                return View();
            else
                return View("History", history.Get());
        }

        [HttpGet]
        [Route("calculator/history/{operand}")]
        public IActionResult History(string operand)
        {
            var history = HttpContext.Session.Get<EvaluationHistory>(HistorySessionKey);
            if (history == null)
                return View();
            else
                return View("History", history.Get(operand));
        }
    }
}
