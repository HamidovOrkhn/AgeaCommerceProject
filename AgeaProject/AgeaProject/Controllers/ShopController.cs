using AgeaProject.Areas.Admin.Helpers;
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
    public class ShopController : Controller
    {
        private readonly DataContext _db;
        public ShopController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index([FromQuery] int page = 0)
        {
            GlobalIndexViewModel<Category> model = new GlobalIndexViewModel<Category>();
            List<Category> data = _db.Categories.ToList();
            float pagecount = data.Count;
            int count = (int)Math.Ceiling(pagecount / 9);

            model.Pagination = ExConverter.PaginationAdvancedMethod(page, count);
            model.Pagination.Count = data.Count;
            model.Pagination.CountInPage = 9;
            model.Data = data.Skip(page * 9).Take(9).ToList();
            return View(model);
        }
    }
}
