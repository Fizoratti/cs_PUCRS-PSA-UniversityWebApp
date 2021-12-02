using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UniversityWebApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(string error)
        {
            return View("Index", error);
        }
    }
}