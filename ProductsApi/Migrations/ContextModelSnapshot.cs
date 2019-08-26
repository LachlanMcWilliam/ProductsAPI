﻿// <auto-generated />
using System;
using BandQ.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsApi;

namespace ProductsApi.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BandQ.Data.Classes.Adress", b =>
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

            modelBuilder.Entity("BandQ.Data.Classes.AdressToCustomer", b =>
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

            modelBuilder.Entity("BandQ.Data.Classes.Customer", b =>
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

            modelBuilder.Entity("BandQ.Data.Classes.Employee", b =>
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

            modelBuilder.Entity("BandQ.Data.Classes.Image", b =>
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

            modelBuilder.Entity("BandQ.Data.Classes.Order", b =>
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

            modelBuilder.Entity("BandQ.Data.Classes.PaymentDetails", b =>
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

            modelBuilder.Entity("BandQ.Data.Classes.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("OrderId");

                    b.Property<decimal>("Price");

                    b.Property<int>("Stock");

                    b.Property<decimal>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BandQ.Data.Classes.AdressToCustomer", b =>
                {
                    b.HasOne("BandQ.Data.Classes.Adress", "Adress")
                        .WithMany("AdressToCustomers")
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BandQ.Data.Classes.Customer", "Customer")
                        .WithMany("AdressToCustomers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BandQ.Data.Classes.Image", b =>
                {
                    b.HasOne("BandQ.Data.Classes.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BandQ.Data.Classes.Order", b =>
                {
                    b.HasOne("BandQ.Data.Classes.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BandQ.Data.Classes.PaymentDetails", "PaymentDetail")
                        .WithMany()
                        .HasForeignKey("PaymentDetailId");
                });

            modelBuilder.Entity("BandQ.Data.Classes.PaymentDetails", b =>
                {
                    b.HasOne("BandQ.Data.Classes.Customer", "Customer")
                        .WithMany("PaymentDetails")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BandQ.Data.Classes.Product", b =>
                {
                    b.HasOne("BandQ.Data.Classes.Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
