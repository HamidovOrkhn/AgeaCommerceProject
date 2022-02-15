using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Models
{
    public class RequestProduct
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string OrderDetails { get; set; }
        public string Desc { get; set; }
        public class RequestProductValidator : AbstractValidator<RequestProduct>
        {
            public RequestProductValidator()
            {
                RuleFor(a => a.Email).NotNull().EmailAddress().MaximumLength(50);
                RuleFor(a => a.Name).NotNull().MaximumLength(70);
                RuleFor(a => a.Surname).NotNull().MaximumLength(70);
                RuleFor(a => a.Address).NotNull().MaximumLength(100);
                RuleFor(a => a.Phone).NotNull().MaximumLength(40);
                RuleFor(a => a.Desc).NotNull().MaximumLength(200);
            }
        }
    }
}
