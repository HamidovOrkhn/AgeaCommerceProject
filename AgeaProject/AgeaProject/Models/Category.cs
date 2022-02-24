using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Src { get; set; }
        public string Desc { get; set; }
        public List<SubCategory> SubCategory { get; set; }
        public class CategoryValidator : AbstractValidator<Category>
        {
            public CategoryValidator()
            {
                RuleFor(a => a.Src).NotNull().MaximumLength(100);
                RuleFor(a => a.Name).NotNull().MaximumLength(100);
                RuleFor(a => a.Desc).NotNull().MaximumLength(240);
            }
        }
    }
    public class CategoryFluent : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(T => T.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(110);
            builder.Property(a => a.Src).IsRequired().HasMaxLength(110);
            builder.Property(a => a.Desc).HasMaxLength(250);
        }
    }
}
