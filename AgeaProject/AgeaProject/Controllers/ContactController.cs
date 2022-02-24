using AgeaProject.Data;
using AgeaProject.Models;
using AgeaProject.ViewModels;
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
            ContactUsViewModel contact = new ContactUsViewModel();

            contact.ContactUs = _db.ContactUs.OrderByDescending(m => m.Id).FirstOrDefault();
            return View(contact);
        }

        [HttpPost]
        public IActionResult CreateBook([FromForm] ContactForm request)
        {
            if (ModelState.IsValid)
            {
                ContactForm model = new ContactForm();
                model.Name = request.Name;
                model.Email = request.Email;
                model.Subject = request.Subject;
                model.Text = request.Text;
                _db.ContactForms.Add(model);
                _db.SaveChanges();
                TempData["Success-form"] = "Messages Added Successfully";
                return RedirectToAction("Index");
            }
            TempData["wrong-form"] = "Messages Not Added";
            return RedirectToAction("Index");
         }
    }
}
