using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.ViewModels
{
    public class CategoryCreateViewModel
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string Desc { get; set; }
    }
    public class CategoryCreateViewModelValidator : AbstractValidator<CategoryCreateViewModel>
    {
        public CategoryCreateViewModelValidator()
        {
            RuleFor(a => a.Image).NotNull();
            RuleFor(a => a.Name).NotNull().MaximumLength(100);
            RuleFor(a => a.Desc).NotNull().MaximumLength(240);
        }
    }
}
