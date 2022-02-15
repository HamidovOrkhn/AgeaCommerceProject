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
            GlobalIndexViewModel<SubCategory> model = new GlobalIndexViewModel<SubCategory>();
            List<SubCategory> data = _db.SubCategories.Include(a=>a.SubCategoryCredentials).ToList();
            if (categoryId>0)
            {
                data.Where(a => a.CategoryId == categoryId).ToList();
            }
            float pagecount = data.Count;
            int count = (int)Math.Ceiling(pagecount / 12);

            model.Pagination = ExConverter.PaginationAdvancedMethod(page, count);
            model.Pagination.Count = data.Count;
            model.Pagination.CountInPage = 12;
            model.Data = data.Skip(page * 12).Take(9).ToList();
            return View(model);
        }
    }
}
