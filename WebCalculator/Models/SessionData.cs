using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCalculator.Models
{
    public class SessionData
    {
        public string UserName { get; set; }
        public string LastResult { get; set; }
        public string Error { get; set; }
    }
}
