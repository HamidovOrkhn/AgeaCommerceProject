using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Areas.Admin.ViewModels.Auth
{
    public class AuthIndexViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class AuthIndexViewModelValidator : AbstractValidator<AuthIndexViewModel>
    {
        public AuthIndexViewModelValidator()
        {
            RuleFor(a => a.Username).NotNull().MaximumLength(100);
            RuleFor(a => a.Password).NotNull().MaximumLength(100);
        }
    }
}
