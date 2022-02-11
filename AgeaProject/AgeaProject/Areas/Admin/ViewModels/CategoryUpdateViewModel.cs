using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.ViewModels
{
    public class CategoryUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string Desc { get; set; }
        public string Src { get; set; }
    }
    public class CategoryUpdateViewModelValidator : AbstractValidator<CategoryUpdateViewModel>
    {
        public CategoryUpdateViewModelValidator()
        {
            RuleFor(a => a.Name).NotNull().MaximumLength(100);
            RuleFor(a => a.Desc).NotNull().MaximumLength(240);
        }
    }
}
