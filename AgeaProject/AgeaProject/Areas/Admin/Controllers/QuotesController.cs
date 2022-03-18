using AgeaProject.Areas.Admin.Helpers;
using AgeaProject.Areas.Admin.ViewModels.Quotes;
using AgeaProject.Data;
using AgeaProject.Filter;
using AgeaProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Login]
    public class QuotesController : Controller
    {
        private readonly DataContext _db;
        public QuotesController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index([FromQuery] int page = 0)
        {
            QuotesIndexViewModel model = new QuotesIndexViewModel();
            List<Quotes> data = _db.Quotes.ToList();
            float pagecount = data.Count;
            int count = (int)Math.Ceiling(pagecount / 10);

            model.Pagination = ExConverter.PaginationMethod(page, count);
            model.Quotes = data.Skip(page * 10).Take(10).ToList();
            return View(model);
        }
        public IActionResult Remove(int id)
        {
            Quotes quote = _db.Quotes.Where(a => a.Id == id).FirstOrDefault();
            if (quote is object)
            {
                _db.Quotes.Remove(quote);
                _db.SaveChanges();
                TempData["Success-Quote"] = "Quote Deleted Successfully";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
