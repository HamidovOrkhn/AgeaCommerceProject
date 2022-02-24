using AgeaProject.Areas.Admin.Resources;
using AgeaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.ViewModels.Products
{
    public class IndexViewModel
    {
        public PaginationDto Pagination { get; set; }
        public List<SubCategory> Data { get; set; }
    }
}
