using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Models
{
    public class ContactUs
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
       
    }
    public class ContactUsValidator : AbstractValidator<ContactUs>
    {
        public ContactUsValidator()
        {
            RuleFor(a => a.Text).NotNull().MaximumLength(500);
            RuleFor(a => a.Phone).NotNull().MaximumLength(20);
            RuleFor(a => a.Address).NotNull().MaximumLength(200);
            RuleFor(a => a.Email).NotNull().MaximumLength(50);
        }
    }
    public class ContactUsFluent : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            builder.HasKey(T => T.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Text).IsRequired().HasMaxLength(500);
            builder.Property(a => a.Phone).IsRequired().HasMaxLength(20);
            builder.Property(a => a.Address).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Email).HasMaxLength(50);
        }
    }
}
