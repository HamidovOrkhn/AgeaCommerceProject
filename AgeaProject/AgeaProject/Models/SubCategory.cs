using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace AgeaProject.Models
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string SKU { get; set; }
        public string Tags { get; set; }
        public string Size { get; set; }
        public string Brand { get; set; }
        public string Options { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<SubCategoryCredential> SubCategoryCredentials { get; set; }
        public class SubCategoryValidator : AbstractValidator<SubCategory>
        {
            public SubCategoryValidator()
            {
                RuleFor(a => a.Name).NotNull().MaximumLength(100);
                RuleFor(a => a.Desc).NotNull().MaximumLength(500);
                RuleFor(a => a.Tags).NotNull().MaximumLength(300);
                RuleFor(a => a.Size).MaximumLength(100);
                RuleFor(a => a.Brand).MaximumLength(100);
                RuleFor(a => a.Options).MaximumLength(700);
                RuleFor(a => a.Price).NotNull();
            }
        }
    }
    public class SubCategoryFluent : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(T => T.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(110);
            builder.Property(a => a.Desc).HasMaxLength(510);
            builder.Property(a => a.Tags).HasMaxLength(310);
            builder.Property(a => a.Size).HasMaxLength(110);
            builder.Property(a => a.Brand).HasMaxLength(110);
            builder.Property(a => a.Options).HasMaxLength(710);
        }
    }
}