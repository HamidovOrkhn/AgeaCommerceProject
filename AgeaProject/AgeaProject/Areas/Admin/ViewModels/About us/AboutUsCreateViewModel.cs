using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.ViewModels.About_us
{
    public class AboutUsCreateViewModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public IFormFile Image { get; set; }
    }
    public class AboutUsCreateViewModelValidator : AbstractValidator<AboutUsCreateViewModel>
    {
        public AboutUsCreateViewModelValidator()
        {
            RuleFor(a => a.Name).NotNull().MaximumLength(100);
            RuleFor(a => a.Title).NotNull().MaximumLength(200);
            RuleFor(a => a.Text).NotNull().MaximumLength(500);
            RuleFor(a => a.Image).NotNull();
        }
    }
}
