using AgeaProject.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.ViewModels.Blog
{
    public class UpdateBlogViewModel 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public IFormFile Src { get; set; }
        public string Image { get; set; }
    }
    public class UpdateBlogViewModelValidator : AbstractValidator<CreateBlogViewModel>
    {
        public UpdateBlogViewModelValidator()
        {
            RuleFor(a => a.Title).NotNull().MaximumLength(100);
            RuleFor(a => a.Text).NotNull().MaximumLength(500);
        }
    }
}
