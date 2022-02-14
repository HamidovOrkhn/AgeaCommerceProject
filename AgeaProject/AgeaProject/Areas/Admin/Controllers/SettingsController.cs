using AgeaProject.Areas.Admin.Helpers;
using AgeaProject.Areas.Admin.ViewModels;
using AgeaProject.Areas.Admin.ViewModels.Contact;
using AgeaProject.Areas.Admin.ViewModels.Settings;
using AgeaProject.Data;
using AgeaProject.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingsController : Controller
    {
        private readonly DataContext _db;
        public SettingsController(DataContext db)
        {
            _db = db;
        }

        public IActionResult Slider()
        {
            var data = _db.SliderAds.ToList();
            return View(data);
        }
        public IActionResult SliderCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SliderCreate([FromForm] SliderCreateViewModel req)
        {
            string fileSrc = FileManager.IFormSaveLocal(req.Image, "sliders");
            SliderAd sliderAd = req.Adapt<SliderAd>();
            sliderAd.Src = fileSrc;
            _db.SliderAds.Add(sliderAd);
            _db.SaveChanges();
            TempData["Success-SliderAd"] = "Slider Added Successfully";
            return RedirectToAction(nameof(Slider));
        }
        public IActionResult SliderRemove(int id)
        {
            SliderAd category = _db.SliderAds.FirstOrDefault(a => a.Id == id);
            if (category is object)
            {
                _db.SliderAds.Remove(category);
                _db.SaveChanges();
                string[] fileNameArr = category.Src.Split("/");
                FileManager.Delete(fileNameArr[1], fileNameArr[0]);
                TempData["Success-SliderAd"] = "SliderAd Deleted Successfully";
            }
            return RedirectToAction(nameof(Slider));
        }
        public IActionResult Contact()
        {
            var data = _db.ContactUs.ToList();
            return View(data);
        }
        public IActionResult ContactCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactCreate([FromForm] ContactCreateViewModel req)
        {
            ContactUs sliderAd = req.Adapt<ContactUs>();
            _db.ContactUs.Add(sliderAd);
            _db.SaveChanges();
            TempData["Success-ContactUs"] = "Contact Added Successfully";
            return RedirectToAction(nameof(Contact));
        }
        public IActionResult ContactRemove(int id)
        {
            ContactUs category = _db.ContactUs.FirstOrDefault(a => a.Id == id);
            if (category is object)
            {
                _db.ContactUs.Remove(category);
                _db.SaveChanges();
                TempData["Success-ContactUs"] = "Contact Deleted Successfully";
            }
            return RedirectToAction(nameof(Contact));
        }
    }
}
