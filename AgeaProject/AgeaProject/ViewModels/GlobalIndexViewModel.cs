using AgeaProject.Areas.Admin.Resources;
using AgeaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.ViewModels
{
    public class GlobalIndexViewModel<T>
    {
        public PaginationAdvancedDto Pagination { get; set; }
        public List<T> Data { get; set; }
    }
}
