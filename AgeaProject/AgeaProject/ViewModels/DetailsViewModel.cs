using AgeaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.ViewModels
{
    public class DetailsViewModel
    {
        public SubCategory Product { get; set; }
        public List<SubCategory> ProductsInCategories { get; set; }
    }
}
