using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.ViewModels.Contact
{
    public class ContactCreateViewModel
    {
        public string Text { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

    }
    public class ContactCreateViewModelValidator : AbstractValidator<ContactCreateViewModel>
    {
        public ContactCreateViewModelValidator()
        {
            RuleFor(a => a.Text).NotNull().MaximumLength(500);
            RuleFor(a => a.Phone).NotNull().MaximumLength(20);
            RuleFor(a => a.Address).NotNull().MaximumLength(200);
            RuleFor(a => a.Email).NotNull().MaximumLength(50);
        }
    }
}
