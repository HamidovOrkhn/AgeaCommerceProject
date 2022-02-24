using AgeaProject.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.ViewModels.Products
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string SKU { get; set; }
        public string Tags { get; set; }
        public string Size { get; set; }
        public string Brand { get; set; }
        public string Options { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }
    }
    public class CreateProductViewModelValidator : AbstractValidator<CreateProductViewModel>
    {
        public CreateProductViewModelValidator()
        {
            RuleFor(a => a.Name).NotNull().MaximumLength(100);
            RuleFor(a => a.Desc).NotNull().MaximumLength(500);
            RuleFor(a => a.Tags).NotNull().MaximumLength(300);
            RuleFor(a => a.Size).MaximumLength(100);
            RuleFor(a => a.Brand).MaximumLength(100);
            RuleFor(a => a.Options).MaximumLength(700);
            RuleFor(a => a.Price).NotNull();
        }
    }
}