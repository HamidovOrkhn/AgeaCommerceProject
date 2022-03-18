using AgeaProject.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgeaProject.Areas.Admin.ViewModels.About_us
{
    public class AboutUsUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public IFormFile Image { get; set; }
    }
    public class AboutUsFluent : IEntityTypeConfiguration<AboutUs>
    {
        public void Configure(EntityTypeBuilder<AboutUs> builder)
        {
            builder.HasKey(T => T.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(110);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(200);
            builder.Property(a => a.Text).IsRequired().HasMaxLength(500);
            builder.Property(a => a.Image).HasMaxLength(250);
        }
    }
    public class AboutUsValidator : AbstractValidator<AboutUs>
    {
        public AboutUsValidator()
        {
            RuleFor(a => a.Name).NotNull().MaximumLength(100);
            RuleFor(a => a.Title).NotNull().MaximumLength(200);
            RuleFor(a => a.Text).NotNull().MaximumLength(500);
            RuleFor(a => a.Image).NotNull().MaximumLength(100);
        }
    }
}
