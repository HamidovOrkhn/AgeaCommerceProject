using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.ViewModels.Products
{
    public class CreateSubCategoryCredentialViewModel
    {
        public IFormFile Image { get; set; }
        public int SubCategoryId { get; set; }
    }
    public class CreateSubCategoryCredentialViewModelValidator : AbstractValidator<CreateSubCategoryCredentialViewModel>
    {
        public CreateSubCategoryCredentialViewModelValidator()
        {
            RuleFor(a => a.Image).NotNull();
        }
    }
}
