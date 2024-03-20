﻿// <auto-generated />
using DemoSalesApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoSalesApp.Migrations.TagDb
{
    [DbContext(typeof(TagDbContext))]
    [Migration("20230316194633_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DemoSalesApp.Models.CategoryTag", b =>
                {
                    b.Property<int>("CategoryTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryTagId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryTagId");

                    b.ToTable("CategoryTags");
                });

            modelBuilder.Entity("DemoSalesApp.Models.SpecTag", b =>
                {
                    b.Property<int>("SpecTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpecTagId"));

                    b.Property<string>("SpecTagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubCategoryTagId")
                        .HasColumnType("int");

                    b.HasKey("SpecTagId");

                    b.HasIndex("SubCategoryTagId");

                    b.ToTable("SpecTags");
                });

            modelBuilder.Entity("DemoSalesApp.Models.SubCategoryTag", b =>
                {
                    b.Property<int>("SubCategoryTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCategoryTagId"));

                    b.Property<int>("CategoryTagId")
                        .HasColumnType("int");

                    b.Property<string>("SubCategoryTagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubCategoryTagId");

                    b.HasIndex("CategoryTagId");

                    b.ToTable("SubCategoryTags");
                });

            modelBuilder.Entity("DemoSalesApp.Models.SpecTag", b =>
                {
                    b.HasOne("DemoSalesApp.Models.SubCategoryTag", "SubCategoryTag")
                        .WithMany()
                        .HasForeignKey("SubCategoryTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubCategoryTag");
                });

            modelBuilder.Entity("DemoSalesApp.Models.SubCategoryTag", b =>
                {
                    b.HasOne("DemoSalesApp.Models.CategoryTag", "CategoryTag")
                        .WithMany()
                        .HasForeignKey("CategoryTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryTag");
                });
#pragma warning restore 612, 618
        }
    }
}
