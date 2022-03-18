using AgeaProject.Areas.Admin.Helpers;
using AgeaProject.Areas.Admin.ViewModels;
using AgeaProject.Data;
using AgeaProject.Filter;
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
    [Login]
    public class CategoriesController : Controller
    {
        private readonly DataContext _db;
        public CategoriesController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index([FromQuery] string searchKey = null, [FromQuery] int page = 0)
        {
            IndexViewModel model = new IndexViewModel();
            List<Category> data = _db.Categories.ToList();
            if (searchKey is object)
            {
                data = data.Where(a=>a.Name.Contains(searchKey)).ToList();
            }
            float pagecount = data.Count;
            int count = (int)Math.Ceiling(pagecount / 10);

            model.Pagination = ExConverter.PaginationMethod(page, count);
            model.Data = data.Skip(page*10).Take(10).ToList();

            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm] CategoryCreateViewModel req)
        {
            string fileSrc = FileManager.IFormSaveLocal(req.Image, "categories");
            _db.Categories.Add(new Category { Desc = req.Desc, Name = req.Name, Src = fileSrc });
            _db.SaveChanges();
            TempData["Success-Category"] = "Category Added Successfully";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int id)
        {
            Category category = _db.Categories.FirstOrDefault(a=>a.Id == id);
            if (category is object)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
                string[] fileNameArr = category.Src.Split("/");
                FileManager.Delete(fileNameArr[1], fileNameArr[0]);
                TempData["Success-Category"] = "Category Deleted Successfully";
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            CategoryUpdateViewModel model = new CategoryUpdateViewModel();
            Category category = _db.Categories.Where(a=>a.Id == id).FirstOrDefault();
            if (category is object)
            {
                model = category.Adapt<CategoryUpdateViewModel>();
                model.Src = category.Src;
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Update([FromForm] CategoryUpdateViewModel req, int id)
        {
            Category category = _db.Categories.Where(a => a.Id == id).FirstOrDefault();
            if (category is object)
            {
                #region Mapping
                category.Name = req.Name;
                category.Src = req.Src;
                category.Desc = req.Desc;
                #endregion=
                if (req.Image is object)
                {
                    string[] fileNameArr = category.Src.Split("/");
                    FileManager.Delete(fileNameArr[1], fileNameArr[0]);
                    string fileSrc = FileManager.IFormSaveLocal(req.Image, "categories");
                    category.Src = fileSrc;
                }
                TempData["Success-Category"] = "Category Updated Successfully";
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
