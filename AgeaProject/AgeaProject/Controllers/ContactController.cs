using AgeaProject.Data;
using AgeaProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly DataContext _db;
        public ContactController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ContactUs contact = _db.ContactUs.OrderByDescending(m => m.Id).FirstOrDefault();
            return View(contact);
        }
    }
}
