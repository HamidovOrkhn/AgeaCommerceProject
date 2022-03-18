using AgeaProject.Filter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Login]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
