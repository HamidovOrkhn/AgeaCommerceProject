using AgeaProject.Data;
using AgeaProject.Models;
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
            AboutUs data = _db.AboutUs.OrderByDescending(m=>m.Id).FirstOrDefault();
            return View(data);
        }
    }
}
