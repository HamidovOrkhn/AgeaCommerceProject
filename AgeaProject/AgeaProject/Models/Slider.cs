using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Prise { get; set; }
        public string Image { get; set; }
    }
    public class SliderValidator : AbstractValidator<Slider>
    {
        public SliderValidator()
        {
            RuleFor(a => a.Title).NotNull().MaximumLength(100);
            RuleFor(a => a.Text).NotNull().MaximumLength(100);
            RuleFor(a => a.Prise).NotNull().MaximumLength(100);
            RuleFor(a => a.Image).NotNull().MaximumLength(20);
        }
    }
    public class SliderFluent : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.HasKey(T => T.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Title).IsRequired().HasMaxLength(200);
            builder.Property(a => a.Text).IsRequired().HasMaxLength(500);
            builder.Property(a => a.Prise).IsRequired().HasMaxLength(10);
            builder.Property(a => a.Image).IsRequired().HasMaxLength(100);

        }
    }
}
