using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampProject.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult ErrorPage404(int code)
        {
            return View();
        }
    }
}
