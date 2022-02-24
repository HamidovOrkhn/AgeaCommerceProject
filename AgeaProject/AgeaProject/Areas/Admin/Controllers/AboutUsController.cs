using AgeaProject.Areas.Admin.Helpers;
using AgeaProject.Areas.Admin.ViewModels.About_us;
using AgeaProject.Data;
using AgeaProject.Filter;
using AgeaProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Login]
    public class AboutUsController : Controller
    {
        private readonly DataContext _db;
        public AboutUsController(DataContext db)
        {
            _db = db;
        }
        // GET: AboutUsController
        public ActionResult Index()
        {
            List<AboutUs> data = _db.AboutUs.OrderByDescending(m=>m.Id).Take(1).ToList();

            return View(data);
        }
        // GET: AboutUsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AboutUsController/Create
        [HttpPost]
        public ActionResult Create([FromForm] AboutUsCreateViewModel request)
        {
            string fileSrc = FileManager.IFormSaveLocal(request.Image, "aboutus");
            var data  = _db.AboutUs.Add(new AboutUs { Name = request.Name, Title = request.Title,Text = request.Text, Image = fileSrc });
            _db.SaveChanges();
            TempData["Success-about"] = "Item Added Successfully";
            return RedirectToAction("Index");
        }

        // GET: AboutUsController/Edit/5
        public ActionResult Update(int id)
        {
            return View();
        }

        // POST: AboutUsController/Edit/5
        [HttpPost]
        public ActionResult Update(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Remove(int id)
        {

            AboutUs data = _db.AboutUs.Find(id);
            if (data is object)
            {
                _db.Remove(data);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
           return RedirectToAction("Index");
        }
    }
}
