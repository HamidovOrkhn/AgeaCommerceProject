using AgeaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.ViewModels
{
    public class BlogViewModel
    {
        public PaginationAdvancedDto Pagination { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
