using AgeaProject.Areas.Admin.Helpers;
using AgeaProject.Data;
using AgeaProject.Models;
using AgeaProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly DataContext _db;
        private readonly IConfiguration _cfg;
        public ContactController(DataContext db, IConfiguration cfg)
        {
            _db = db;
            _cfg = cfg; 
        }
        public IActionResult Index()
        {
            ContactUsViewModel contact = new ContactUsViewModel();

            contact.ContactUs = _db.ContactUs.OrderByDescending(m => m.Id).FirstOrDefault();
            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromForm] ContactForm request)
        {
            if (ModelState.IsValid)
            {
                ContactForm model = new ContactForm();
                model.Name = request.Name;
                model.Email = request.Email;
                model.Subject = request.Subject;
                model.Text = request.Text;
                _db.ContactForms.Add(model);
                string bodyString = $"Name : {request.Name} <br>" +
                                    $"Email : {request.Email} <br>" +
                                    $"Subject : {request.Subject} <br>" +
                                    $"Text : {request.Text} <br>";
                try
                {
                    await MailService.SendEmailAsync(new MailRequest { Body = bodyString, Subject = "AgeaFire Contact Us Request", ToEmail = _cfg["MailSettings:ToMail"] });
                    _db.SaveChanges();
                    TempData["Success-form"] = "Messages Added Successfully";
                }
                catch(Exception x)
                {
                    TempData["Wrong-form"] = x.Message;
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            TempData["Wrong-form"] = "Messages Not Added";
            return RedirectToAction("Index");
         }
    }
}
