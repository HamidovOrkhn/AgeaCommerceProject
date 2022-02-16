using AgeaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.ViewModels
{
    public class ProductIndexViewModel
    {
        public PaginationAdvancedDto Pagination { get; set; }
        public List<SubCategory> Data { get; set; }
        public List<Category> Categories { get; set; }
    }
}
