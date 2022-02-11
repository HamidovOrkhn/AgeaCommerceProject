using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.Resources
{
    public class PaginationDto
    {
        public int StartPage { get; set; }
        public int Page { get; set; }
        public int PageCount { get; set; }
        public int EndPage { get; set; }
    }
}
