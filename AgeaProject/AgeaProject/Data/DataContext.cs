using AgeaProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.Data
{
    public class DataContext:DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var configName = string.Empty;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                configName = "appsettings.Development.json";
            }
            else
            {
                configName = "appsettings.json";
            }
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile(configName).Build();
            if (!options.IsConfigured)
            {
                options.UseMySQL(configuration.GetConnectionString(nameof(DataContext)));
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryFluent());
            builder.ApplyConfiguration(new SubCategoryFluent());
            builder.ApplyConfiguration(new SubCategoryCredentialFluent());
            builder.ApplyConfiguration(new SliderAdFluent());
            builder.ApplyConfiguration(new ContactUsFluent());
            builder.ApplyConfiguration(new QuotesFluent());
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SubCategoryCredential> SubCategoryCredentials { get; set; }
        public DbSet<SliderAd> SliderAds { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCredentials> BlogCredentials { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Quotes> Quotes { get; set; }
    }
}
