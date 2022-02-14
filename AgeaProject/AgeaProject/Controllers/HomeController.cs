using AgeaProject.Data;
using AgeaProject.Extensions;
using AgeaProject.Models;
using AgeaProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _db;
        public HomeController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            List<GlCount> counterMax = _db.Categories
                .AsEnumerable()
                .Select(a => new GlCount { CategoryId = a.Id, GCount = a.SubCategory is object ? a.SubCategory.Count() : 0 })
                .OrderByDescending(a => a.GCount)
                .ToList()
                .TakeLastSafe(2)
                .ToList();
            List<Category> dataNav = _db.Categories.Include(a => a.SubCategory).AsEnumerable().Select(a => new Category { Id = a.Id, Name = a.Name, SubCategory = a.SubCategory.TakeLastSafe(10) }).ToList();
            List<Category> dataNew = _db.Categories.ToList().TakeLastSafe(2).ToList();
            List<SubCategory> datanNewSubCategory = _db.SubCategories.Include(a=>a.Category).ToList().TakeSafe(8).ToList();
            List<SubCategory> dataMostSubCategory = _db.SubCategories.Include(a => a.Category).Include(a=>a.SubCategoryCredentials).ToList().TakeLastSafe(8).ToList();
            List<Category> dataMost = _db.Categories.ToList().TakeSafe(2).ToList();
            List<SliderAd> slider = _db.SliderAds.ToList();
            model.SubCategoriesNew = datanNewSubCategory;
            model.CategoriesMost = dataMost;
            model.CategoriesNav = dataNav;
            model.CategoriesNew = dataNew;
            model.SliderMain = slider;
            model.SubCategoriesMost = dataMostSubCategory;
            return View(model);
        }
        public IActionResult Details(int id)
        {
            DetailsViewModel model = new DetailsViewModel();
            SubCategory prod = _db.SubCategories.Where(a => a.Id == id).Include(a => a.SubCategoryCredentials).Include(a=>a.Category).FirstOrDefault();
            List<SubCategory> subCategories = _db.SubCategories
                .Where(a => a.CategoryId == (prod is object ? prod.CategoryId : 0) && a.Id != (prod is object ? prod.Id : 0))
                .ToList()
                .TakeSafe(10)
                .ToList();
            model.Product = prod;
            model.ProductsInCategories = subCategories;
            return View(model);
        }
        public IActionResult GetShopItem(int id)
        {
            return Json(_db.SubCategories.Where(a=>a.Id == id).Include(a => a.SubCategoryCredentials).FirstOrDefault());
        }
        public IActionResult ShoppingCard()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetShop([FromBody]List<string> keys)
        {
            List<SubCategory> data = (from a in _db.SubCategories.Include(a => a.SubCategoryCredentials).ToList()
                                      join b in keys on a.Id equals int.Parse(b)
                                      select a).ToList();
            return Json(data);
        }

    }
}
