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
    public class BlogCredentials
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
    public class BlogCredentialsValidator : AbstractValidator<BlogCredentials>
    {
        public BlogCredentialsValidator()
        {
            RuleFor(a => a.Image).NotNull().MaximumLength(100);
        }
    }
    public class BlogCredentialsFluent : IEntityTypeConfiguration<BlogCredentials>
    {
        public void Configure(EntityTypeBuilder<BlogCredentials> builder)
        {
            builder.HasKey(T => T.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Image).IsRequired().HasMaxLength(100);
        }
    }
}
