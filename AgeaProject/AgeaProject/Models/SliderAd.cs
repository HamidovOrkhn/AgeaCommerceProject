using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Models
{
    public class SliderAd
    {
        public int Id { get; set; }
        public string TextHeader { get; set; }
        public string TextBody { get; set; }
        public string TextFooter { get; set; }
        public string Src { get; set; }
    }
    public class SliderAdValidator : AbstractValidator<SliderAd>
    {
        public SliderAdValidator()
        {
            RuleFor(a => a.TextHeader).MaximumLength(51);
            RuleFor(a => a.TextBody).MaximumLength(51);
            RuleFor(a => a.TextFooter).MaximumLength(51);
        }
    }
    public class SliderAdFluent : IEntityTypeConfiguration<SliderAd>
    {
        public void Configure(EntityTypeBuilder<SliderAd> builder)
        {
            builder.HasKey(T => T.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Src).IsRequired().HasMaxLength(100);
            builder.Property(a => a.TextHeader).HasMaxLength(50);
            builder.Property(a => a.TextFooter).HasMaxLength(50);
            builder.Property(a => a.TextBody).HasMaxLength(50);
        }
    }
}
