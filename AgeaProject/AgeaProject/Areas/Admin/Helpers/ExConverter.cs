using AgeaProject.Areas.Admin.Resources;
using AgeaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.Helpers
{
    public class ExConverter
    {
        public static PaginationDto PaginationMethod(int page, int pagecount)
        {
            if (page <= 5 || pagecount <= 9)
            {
                if (pagecount <= 9)
                {
                    return new PaginationDto() { StartPage = 0, PageCount = pagecount, Page = page, EndPage = pagecount - 1 };
                }
                else
                {
                    return new PaginationDto() { StartPage = 0, PageCount = pagecount, Page = page, EndPage = 9 };
                }
            }
            else if (page > pagecount - 5)
            {
                return new PaginationDto() { StartPage = page - 9, PageCount = pagecount, Page = page, EndPage = pagecount - 1 };
            }
            else
            {
                return new PaginationDto() { StartPage = page - 5, PageCount = pagecount, Page = page, EndPage = page + 4 };
            }
        }
        public static PaginationAdvancedDto PaginationAdvancedMethod(int page, int pagecount)
        {
            if (page <= 5 || pagecount <= 9)
            {
                if (pagecount <= 9)
                {
                    return new PaginationAdvancedDto() { StartPage = 0, PageCount = pagecount, Page = page, EndPage = pagecount - 1 };
                }
                else
                {
                    return new PaginationAdvancedDto() { StartPage = 0, PageCount = pagecount, Page = page, EndPage = 9 };
                }
            }
            else if (page > pagecount - 5)
            {
                return new PaginationAdvancedDto() { StartPage = page - 9, PageCount = pagecount, Page = page, EndPage = pagecount - 1 };
            }
            else
            {
                return new PaginationAdvancedDto() { StartPage = page - 5, PageCount = pagecount, Page = page, EndPage = page + 4 };
            }
        }
    }
}
