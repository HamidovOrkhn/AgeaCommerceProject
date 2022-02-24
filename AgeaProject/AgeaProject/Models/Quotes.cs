using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Models
{
    public class Quotes:RequestProduct
    {
        public int Id { get; set; }
        public DateTime DDate { get; set; } = DateTime.Now;
    }
    public class QuotesFluent : IEntityTypeConfiguration<Quotes>
    {
        public void Configure(EntityTypeBuilder<Quotes> builder)
        {
            builder.HasKey(T => T.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(71);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(51);
            builder.Property(a => a.Surname).IsRequired().HasMaxLength(71);
            builder.Property(a => a.Address).IsRequired().HasMaxLength(101);
            builder.Property(a => a.Phone).IsRequired().HasMaxLength(41);
            builder.Property(a => a.Desc).IsRequired().HasMaxLength(201);
        }
    }
}
