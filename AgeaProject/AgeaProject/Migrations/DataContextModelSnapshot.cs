﻿// <auto-generated />
using System;
using AgeaProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AgeaProject.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AgeaProject.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Desc")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(110)")
                        .HasMaxLength(110);

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("varchar(110)")
                        .HasMaxLength(110);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AgeaProject.Models.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .HasColumnType("varchar(110)")
                        .HasMaxLength(110);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Desc")
                        .HasColumnType("varchar(510)")
                        .HasMaxLength(510);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(110)")
                        .HasMaxLength(110);

                    b.Property<string>("Options")
                        .HasColumnType("varchar(710)")
                        .HasMaxLength(710);

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<string>("SKU")
                        .HasColumnType("text");

                    b.Property<string>("Size")
                        .HasColumnType("varchar(110)")
                        .HasMaxLength(110);

                    b.Property<string>("Tags")
                        .HasColumnType("varchar(310)")
                        .HasMaxLength(310);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("AgeaProject.Models.SubCategoryCredential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("varchar(110)")
                        .HasMaxLength(110);

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("SubCategoryCredentials");
                });

            modelBuilder.Entity("AgeaProject.Models.SubCategory", b =>
                {
                    b.HasOne("AgeaProject.Models.Category", "Category")
                        .WithMany("SubCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgeaProject.Models.SubCategoryCredential", b =>
                {
                    b.HasOne("AgeaProject.Models.SubCategory", "SubCategory")
                        .WithMany("SubCategoryCredentials")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
