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
    public class Blog:BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }

        public List<BlogCredentials> BlogCredentials { get; set; }
    }
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(a => a.Title).NotNull().MaximumLength(100);
            RuleFor(a => a.Text).NotNull().MaximumLength(500);
            RuleFor(a => a.Image).NotNull().MaximumLength(100);
        }
    }
    public class BlogFluent : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(T => T.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Title).IsRequired().HasMaxLength(110);
            builder.Property(a => a.Text).IsRequired().HasMaxLength(500);
            builder.Property(a => a.Image).HasMaxLength(250);
        }
    }
}
