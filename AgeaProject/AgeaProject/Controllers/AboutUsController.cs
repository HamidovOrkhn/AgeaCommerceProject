using AgeaProject.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly DataContext _db;
        public AboutUsController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var data = _db.AboutUs.FirstOrDefault();
            return View(data);
        }
    }
}
