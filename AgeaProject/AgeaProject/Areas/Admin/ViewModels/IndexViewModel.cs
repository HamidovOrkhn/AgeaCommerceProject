using AgeaProject.Areas.Admin.Resources;
using AgeaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.ViewModels
{
    public class IndexViewModel
    {
        public PaginationDto Pagination { get; set; }
        public List<Category> Data { get; set; }
    }
}
