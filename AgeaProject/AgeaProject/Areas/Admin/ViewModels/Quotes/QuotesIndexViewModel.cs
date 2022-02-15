using AgeaProject.Areas.Admin.Resources;
using AgeaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.ViewModels.Quotes
{
    public class QuotesIndexViewModel
    {
        public PaginationDto Pagination { get; set; }
        public List <AgeaProject.Models.Quotes> Quotes { get; set; }
    }
}
