using AgeaProject.Areas.Admin.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.ViewModels.Blog
{
    public class BlogListViewModel
    {
        public List<Models.Blog> Blogs { get; set; }
        public PaginationDto Pagination { get; set; }
    }
}
