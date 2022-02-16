using AgeaProject.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.ViewModels.Blog
{
    public class CreateBlogViewModel : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public IFormFile Image { get; set; }
    }
    public class CreateBlogViewModelValidator : AbstractValidator<CreateBlogViewModel>
    {
        public CreateBlogViewModelValidator()
        {
            RuleFor(a => a.Title).NotNull().MaximumLength(100);
            RuleFor(a => a.Text).NotNull().MaximumLength(500);
        }
    }
}
