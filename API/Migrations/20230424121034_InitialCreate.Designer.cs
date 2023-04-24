﻿// <auto-generated />
using API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20230424121034_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Human", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Humans");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Human");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("API.Models.Item", b =>
                {
                    b.Property<int>("Itemid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Itemid"));

                    b.Property<int>("Discounted")
                        .HasColumnType("int");

                    b.Property<int>("inStock")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("reOrdered")
                        .HasColumnType("int");

                    b.HasKey("Itemid");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("API.Models.Customer", b =>
                {
                    b.HasBaseType("API.Models.Human");

                    b.Property<decimal>("amountBought")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("humanId")
                        .HasColumnType("int");

                    b.Property<int>("productsBought")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.HasBaseType("API.Models.Human");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
