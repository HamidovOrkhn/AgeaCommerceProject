using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public string HeaderLogo { get; set; }
        public string FooterLogo { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
    }
    public class SettingValidator : AbstractValidator<Setting>
    {
        public SettingValidator()
        {
            RuleFor(a => a.HeaderLogo).NotNull().MaximumLength(100);
            RuleFor(a => a.FooterLogo).NotNull().MaximumLength(100);
            RuleFor(a => a.Address).NotNull().MaximumLength(100);
            RuleFor(a => a.Phone).NotNull().MaximumLength(20);
            RuleFor(a => a.Email).NotNull().MaximumLength(50);
            RuleFor(a => a.Text).NotNull().MaximumLength(500);
        }
    }
    public class SettingFluent : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasKey(T => T.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.HeaderLogo).IsRequired().HasMaxLength(100);
            builder.Property(a => a.FooterLogo).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Address).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Phone).HasMaxLength(25);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Text).IsRequired().HasMaxLength(500);
        }
    }
}
