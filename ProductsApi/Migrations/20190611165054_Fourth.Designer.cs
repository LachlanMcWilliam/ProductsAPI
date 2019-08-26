﻿// <auto-generated />
using System;
using BandQ.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsApi;

namespace ProductsApi.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190611165054_Fourth")]
    partial class Fourth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductsApi.Entities.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PostCode");

                    b.Property<string>("Street");

                    b.Property<string>("Town");

                    b.HasKey("Id");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("ProductsApi.Entities.AdressToCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdressId");

                    b.Property<int>("CustomerId");

                    b.HasKey("Id");

                    b.HasIndex("AdressId");

                    b.HasIndex("CustomerId");

                    b.ToTable("AdressToCustomer");
                });

            modelBuilder.Entity("ProductsApi.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ProductsApi.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Role");

                    b.Property<DateTime>("insert_time");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ProductsApi.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Data");

                    b.Property<string>("Extension");

                    b.Property<string>("FileName");

                    b.Property<string>("MimeType");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ProductsApi.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdressId");

                    b.Property<int>("CustomerId");

                    b.Property<bool>("HasBeenOrdered");

                    b.Property<int>("NumberOfProducts");

                    b.Property<int?>("PaymentDetailId");

                    b.Property<int>("PaymentId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentDetailId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ProductsApi.Entities.PaymentDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardNumber");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("ExpireyDate");

                    b.Property<string>("NameOnCard");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("PaymentDetails");
                });

            modelBuilder.Entity("ProductsApi.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("OrderId");

                    b.Property<int>("Price");

                    b.Property<int>("Stock");

                    b.Property<decimal>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductsApi.Entities.AdressToCustomer", b =>
                {
                    b.HasOne("ProductsApi.Entities.Adress", "Adress")
                        .WithMany("AdressToCustomers")
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProductsApi.Entities.Customer", "Customer")
                        .WithMany("AdressToCustomers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProductsApi.Entities.Image", b =>
                {
                    b.HasOne("ProductsApi.Entities.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProductsApi.Entities.Order", b =>
                {
                    b.HasOne("ProductsApi.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProductsApi.Entities.PaymentDetails", "PaymentDetail")
                        .WithMany()
                        .HasForeignKey("PaymentDetailId");
                });

            modelBuilder.Entity("ProductsApi.Entities.PaymentDetails", b =>
                {
                    b.HasOne("ProductsApi.Entities.Customer", "Customer")
                        .WithMany("PaymentDetails")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProductsApi.Entities.Product", b =>
                {
                    b.HasOne("ProductsApi.Entities.Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
