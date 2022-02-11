using AgeaProject.Data;
using AgeaProject.Models;
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
        public IActionResult Index()
        {
            List<Blog> blog = _db.Blogs.OrderByDescending(m=>m.Id)
                .Take(9).ToList();
            return View(blog);
        }
        public IActionResult Single(int id)
        {
            Blog blog = _db.Blogs.Where(m=>m.Id == id).FirstOrDefault();
            return View(blog);
        }
    }
}
