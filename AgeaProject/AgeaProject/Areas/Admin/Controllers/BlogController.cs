using AgeaProject.Areas.Admin.Helpers;
using AgeaProject.Areas.Admin.ViewModels;
using AgeaProject.Areas.Admin.ViewModels.Blog;
using AgeaProject.Data;
using AgeaProject.Filter;
using AgeaProject.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Login]
    public class BlogController : Controller
    {
        private readonly DataContext _db;
        public BlogController(DataContext db)
        {
            _db = db;
        }
        // GET: BlogController
        public ActionResult Index([FromQuery] int page = 0)
        {
            BlogListViewModel model = new BlogListViewModel();
            List<Blog> blogs = _db.Blogs.OrderByDescending(m=>m.Id).ToList();
            float pagecount = blogs.Count;
            int count = (int)Math.Ceiling(pagecount / 10);

            model.Pagination = ExConverter.PaginationMethod(page, count);
            model.Blogs = blogs.Skip(page * 10).Take(10).ToList();

            return View(model);
        }

        // GET: BlogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogController/Create
        [HttpPost]
        public ActionResult Create([FromForm] CreateBlogViewModel request)
        {
            string fileSrc = FileManager.IFormSaveLocal(request.Image, "blogs");
            _db.Blogs.Add(new Blog { Title = request.Title, Text = request.Text,CreatedDate = DateTime.Now, Image = fileSrc });
            _db.SaveChanges();
            TempData["Success-Blog"] = "Blog Added Successfully";
            return RedirectToAction(nameof(Index));
        }

        // GET: BlogController/Edit/5
        public ActionResult Update(int id)
        {
            UpdateBlogViewModel model = new UpdateBlogViewModel();
            Blog blog = _db.Blogs.Where(a => a.Id == id).FirstOrDefault();
            if (blog is object)
            {
                model = blog.Adapt<UpdateBlogViewModel>();
                model.Image = blog.Image;
            }
            return View(model);
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        public ActionResult Update([FromForm] UpdateBlogViewModel req, int id)
        {
            Blog blog = _db.Blogs.Where(a => a.Id == id).FirstOrDefault();
            if (blog is object)
            {
                #region Mapping
                blog.Title = req.Title;
                blog.Text = req.Text;
                #endregion
                string filename = blog.Image;
                if (req.Src is object)
                {
                    string[] fileNameArr = filename.Split("/");
                    FileManager.Delete(fileNameArr[1], fileNameArr[0]);
                    filename = FileManager.IFormSaveLocal(req.Src, "blogs");
                    blog.Image = filename;
                }
                TempData["Success-Category"] = "Blog Updated Successfully";
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: BlogController/Delete/5
        public ActionResult Delete(int id)
        {
            Blog blog = _db.Blogs.FirstOrDefault(a => a.Id == id);
            if (blog is object)
            {
                _db.Blogs.Remove(blog);
                _db.SaveChanges();
                TempData["Success-Category"] = "Blog Deleted Successfully";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
