using AgeaProject.Areas.Admin.Helpers;
using AgeaProject.Areas.Admin.ViewModels.Products;
using AgeaProject.Data;
using AgeaProject.Filter;
using AgeaProject.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Login]
    public class ProductsController : Controller
    {
        private readonly DataContext _db;
        public ProductsController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index([FromQuery] string searchKey = null, [FromQuery] int page = 0)
        {
            IndexViewModel model = new IndexViewModel();
            List<SubCategory> data = _db.SubCategories.Include(a => a.Category).ToList();
            if (searchKey is object)
            {
                data = data.Where(a => a.Name.Contains(searchKey)).ToList();
            }
            float pagecount = data.Count;
            int count = (int)Math.Ceiling(pagecount / 10);

            model.Pagination = ExConverter.PaginationMethod(page, count);
            model.Data = data.Skip(page * 10).Take(10).ToList();

            return View(model);
        }
        public IActionResult Create()
        {
            CreateProductViewModel model = new CreateProductViewModel();
            model.Categories = _db.Categories.Select(a => new Category { Id = a.Id, Name = a.Name }).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create([FromForm] CreateProductViewModel req)
        {
            SubCategory category = req.Adapt<SubCategory>();
            _db.SubCategories.Add(category);
            _db.SaveChanges();
            TempData["Success-Product"] = "Product Added Successfully";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int id)
        {
            SubCategory subcategory = _db.SubCategories.Include(a => a.SubCategoryCredentials).FirstOrDefault(a => a.Id == id);
            if (subcategory is object)
            {
                _db.SubCategories.Remove(subcategory);
                _db.SaveChanges();
                foreach (var item in subcategory.SubCategoryCredentials)
                {
                    string[] fileNameArr = item.Src.Split("/");
                    FileManager.Delete(fileNameArr[1], fileNameArr[0]);
                }
                TempData["Success-Product"] = "Product Deleted Successfully";
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            UpdateProductViewModel model = new UpdateProductViewModel();
            SubCategory subcategory = _db.SubCategories.Where(a => a.Id == id).Include(a => a.Category).FirstOrDefault();
            if (subcategory is object)
            {
                model = subcategory.Adapt<UpdateProductViewModel>();
                model.Categories = _db.Categories.Select(a => new Category { Id = a.Id, Name = a.Name }).ToList();
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Update([FromForm] UpdateProductViewModel req, int id)
        {
            SubCategory subcategory = _db.SubCategories.Where(a => a.Id == id).FirstOrDefault();
            if (subcategory is object)
            {
                #region Mapping
                subcategory.Name = req.Name;
                subcategory.Options = req.Options;
                subcategory.Price = req.Price;
                subcategory.Size = req.Size;
                subcategory.SKU = req.SKU;
                subcategory.Tags = req.Tags;
                subcategory.Brand = req.Brand;
                subcategory.CategoryId = req.CategoryId;
                subcategory.Desc = req.Desc;
                #endregion
                TempData["Success-Product"] = "Product Updated Successfully";
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Pictures(int id)
        {
            SubCategory subcategory = _db.SubCategories.Where(a => a.Id == id).Include(a => a.Category).Include(a=>a.SubCategoryCredentials).FirstOrDefault();
            List<SubCategoryCredential> model = new List<SubCategoryCredential>();
            if (subcategory is object)
            {
                ViewData["CategoryName"] = subcategory.Category.Name;
                ViewData["ProductName"] = subcategory.Name;
                model = subcategory.SubCategoryCredentials.OrderByDescending(a=>a.Id).ToList();
            }
            return View(model);
        }
        public IActionResult AddPicture(int id)
        {
            SubCategory subcategory = _db.SubCategories.Where(a => a.Id == id).Include(a => a.Category).FirstOrDefault();
            CreateSubCategoryCredentialViewModel model = new CreateSubCategoryCredentialViewModel();
            if (subcategory is object)
            {
                ViewData["CategoryName"] = subcategory.Category.Name;
                ViewData["ProductName"] = subcategory.Name;
                model.SubCategoryId = subcategory.Id;
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult AddPicture([FromForm] CreateSubCategoryCredentialViewModel req, int id)
        {
            SubCategory subcategory = _db.SubCategories.Where(a => a.Id == id).FirstOrDefault();
            if (subcategory is object)
            {
                string fileSrc = FileManager.IFormSaveLocal(req.Image, "product_pictures");
                _db.SubCategoryCredentials.Add(new SubCategoryCredential { SubCategoryId = id, Src = fileSrc });
                _db.SaveChanges();
                TempData["Success-Credentials"] = "Picture Added Successfully";
            }
            return RedirectToAction(nameof(Pictures), new { id = id });
        }
        public IActionResult RemovePicture(int id)
        {
            SubCategoryCredential crd = _db.SubCategoryCredentials.Where(a => a.Id == id).FirstOrDefault();
            if (crd is object)
            {
                _db.SubCategoryCredentials.Remove(crd);
                _db.SaveChanges();
                string[] fileNameArr = crd.Src.Split("/");
                FileManager.Delete(fileNameArr[1], fileNameArr[0]);
                TempData["Success-Credentials"] = "Picture Deleted Successfully";
            }
            return RedirectToAction(nameof(Pictures), new { id = crd.SubCategoryId });
        }
    }
}
