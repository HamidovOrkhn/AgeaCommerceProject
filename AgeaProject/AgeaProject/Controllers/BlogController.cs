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
    public class BlogController : Controller
    {
        private readonly DataContext _db;
        public BlogController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index([FromQuery] int page = 0)
        {
            BlogViewModel model = new BlogViewModel();
            List<Blog> blog = _db.Blogs.OrderByDescending(m => m.Id)
                 .ToList();
            float pagecount = blog.Count;
            int count = (int)Math.Ceiling(pagecount / 9);
            model.Pagination = ExConverter.PaginationAdvancedMethod(page, count);
            model.Pagination.Count = blog.Count;
            model.Pagination.CountInPage = 9;
            model.Blogs = blog.Skip(page * 9).Take(9).ToList();
            return View(model);
        }
        public IActionResult Single(int id)
        
        {
            var blog = _db.Blogs.Where(m=>m.Id == id).FirstOrDefault();
            return View(blog);
        }
    }
}
