﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_geekstore.Data;

#nullable disable

namespace api_geekstore.Data.Migrations
{
    [DbContext(typeof(APIGeekStoreContext))]
    partial class APIGeekStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.29");

            modelBuilder.Entity("api_geekstore.Shared.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("address");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("birth_date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("last_name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT")
                        .HasColumnName("phone_number");

                    b.HasKey("Id");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("api_geekstore.Shared.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("client_id");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("delivery_date");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("order_date");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("INTEGER")
                        .HasColumnName("order_number");

                    b.HasKey("Id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("api_geekstore.Shared.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("order_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER")
                        .HasColumnName("quantity");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("order-details");
                });

            modelBuilder.Entity("api_geekstore.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT")
                        .HasColumnName("price");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("category_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("api_geekstore.Shared.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("category_name");

                    b.HasKey("Id");

                    b.ToTable("product_categories");
                });

            modelBuilder.Entity("api_geekstore.Shared.OrderDetail", b =>
                {
                    b.HasOne("api_geekstore.Shared.Order", null)
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_geekstore.Shared.Product", null)
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api_geekstore.Shared.Product", b =>
                {
                    b.HasOne("api_geekstore.Shared.ProductCategory", null)
                        .WithMany("ProductList")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api_geekstore.Shared.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("api_geekstore.Shared.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("api_geekstore.Shared.ProductCategory", b =>
                {
                    b.Navigation("ProductList");
                });
#pragma warning restore 612, 618
        }
    }
}
