using AgeaProject.Areas.Admin.Helpers;
using AgeaProject.Data;
using AgeaProject.Models;
using AgeaProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DataContext _db;
        public ProductsController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index([FromQuery] int page = 0, [FromQuery] int categoryId = 0)
        {
            ProductIndexViewModel model = new ProductIndexViewModel();
            List<SubCategory> data = _db.SubCategories.Include(a => a.SubCategoryCredentials).Include(a => a.Category).ToList();
            List<Category> categories = _db.Categories.AsEnumerable().Select(a => new Category { Id = a.Id, Name = a.Name }).ToList();
            if (categoryId > 0)
            {
                data = data.Where(a => a.CategoryId == categoryId).ToList();
            }
            float pagecount = data.Count;
            int count = (int)Math.Ceiling(pagecount / 12);

            model.Pagination = ExConverter.PaginationAdvancedMethod(page, count);
            model.Pagination.Count = data.Count;
            model.Pagination.CountInPage = 12;
            model.Data = data.Skip(page * 12).Take(12).ToList();
            model.Categories = categories;
            return View(model);
        }
    }
}
