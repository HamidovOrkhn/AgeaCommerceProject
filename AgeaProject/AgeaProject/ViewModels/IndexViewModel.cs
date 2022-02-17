using AgeaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.ViewModels
{
    public class IndexViewModel
    {
        public List<Category> CategoriesNav { get; set; }
        public List<Category> CategoriesNew { get; set; }
        public List<SubCategory> SubCategoriesNew { get; set; }
        public List<SubCategory> SubCategoriesMost { get; set; }
        public List<Category> CategoriesMost { get; set; }
        public List<SliderAd> SliderMain { get; set; }
        public ContactUs ContactUs { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
