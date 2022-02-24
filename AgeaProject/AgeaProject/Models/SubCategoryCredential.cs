using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgeaProject.Models
{
    public class SubCategoryCredential
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public class SubCategoryCredentialValidator : AbstractValidator<SubCategoryCredential>
        {
            public SubCategoryCredentialValidator()
            {
                RuleFor(a => a.Src).NotNull().MaximumLength(100);
            }
        }
    }
    public class SubCategoryCredentialFluent : IEntityTypeConfiguration<SubCategoryCredential>
    {
        public void Configure(EntityTypeBuilder<SubCategoryCredential> builder)
        {
            builder.HasKey(T => T.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Src).IsRequired().HasMaxLength(110);
        }
    }
}