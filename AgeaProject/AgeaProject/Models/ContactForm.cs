using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Models
{
    public class ContactForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
       
    }
    public class ContactFormValidator : AbstractValidator<ContactForm>
    {
        public ContactFormValidator()
        {
            RuleFor(a => a.Name).NotNull().MaximumLength(100);
            RuleFor(a => a.Email).NotNull().MaximumLength(50);
            RuleFor(a => a.Subject).NotNull().MaximumLength(100);
            RuleFor(a => a.Text).NotNull().MaximumLength(500);
        }
    }
    public class ContactFormFluent : IEntityTypeConfiguration<ContactForm>
    {
        public void Configure(EntityTypeBuilder<ContactForm> builder)
        {
            builder.HasKey(T => T.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(110);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Subject).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Text).HasMaxLength(500);
        }
    }
}
