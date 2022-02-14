using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.ViewModels.Settings
{
    public class SliderCreateViewModel
    {
        public int Id { get; set; }
        public string TextHeader { get; set; }
        public string TextBody { get; set; }
        public string TextFooter { get; set; }
        public IFormFile Image { get; set; }
    }
    public class SliderCreateViewModelValidator : AbstractValidator<SliderCreateViewModel>
    {
        public SliderCreateViewModelValidator()
        {
            RuleFor(a => a.Image).NotNull();
            RuleFor(a => a.TextHeader).MaximumLength(51);
            RuleFor(a => a.TextBody).MaximumLength(51);
            RuleFor(a => a.TextFooter).MaximumLength(51);
        }
    }
}
