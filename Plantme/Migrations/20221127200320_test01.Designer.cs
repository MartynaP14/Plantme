﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Plantme.Data;

#nullable disable

namespace Plantme.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221127200320_test01")]
    partial class test01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Plantme.Models.OrderItemInfo", b =>
                {
                    b.Property<int>("OrderItemInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemInfoId"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductOrderID")
                        .HasColumnType("int");

                    b.HasKey("OrderItemInfoId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductOrderID");

                    b.ToTable("OrderItemInfo");
                });

            modelBuilder.Entity("Plantme.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<bool>("BeginnerFriendly")
                        .HasColumnType("bit");

                    b.Property<bool>("ChildFriendly")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("DifficultyLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Documentation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GrowingConditions")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("PetFriendly")
                        .HasColumnType("bit");

                    b.Property<string>("PlantingInstructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("ProductPrice")
                        .HasColumnType("real");

                    b.Property<int>("ProductTypes")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Plantme.Models.ProductOrder", b =>
                {
                    b.Property<int>("ProductOrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductOrderID"), 1L, 1);

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("OrderDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderQuantity")
                        .HasColumnType("int");

                    b.Property<int>("OrderSubtotal")
                        .HasColumnType("int");

                    b.HasKey("ProductOrderID");

                    b.HasIndex("Id");

                    b.ToTable("ProductOrder");
                });

            modelBuilder.Entity("Plantme.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLoginName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserPhoneNo")
                        .HasColumnType("int");

                    b.Property<string>("UserSurname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Plantme.Models.OrderItemInfo", b =>
                {
                    b.HasOne("Plantme.Models.Product", "Product")
                        .WithMany("OrderItemInfo")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Plantme.Models.ProductOrder", "ProductOrder")
                        .WithMany("OrderItemInfo")
                        .HasForeignKey("ProductOrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductOrder");
                });

            modelBuilder.Entity("Plantme.Models.ProductOrder", b =>
                {
                    b.HasOne("Plantme.Models.User", "User")
                        .WithMany("ProductOrder")
                        .HasForeignKey("Id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Plantme.Models.Product", b =>
                {
                    b.Navigation("OrderItemInfo");
                });

            modelBuilder.Entity("Plantme.Models.ProductOrder", b =>
                {
                    b.Navigation("OrderItemInfo");
                });

            modelBuilder.Entity("Plantme.Models.User", b =>
                {
                    b.Navigation("ProductOrder");
                });
#pragma warning restore 612, 618
        }
    }
}
