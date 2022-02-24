using AgeaProject.Areas.Admin.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Models
{
    public class PaginationAdvancedDto:PaginationDto
    {
        public int Count { get; set; }
        public int CountInPage { get; set; }
    }
}
