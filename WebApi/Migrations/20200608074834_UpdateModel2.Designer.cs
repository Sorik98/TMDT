﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Database.Context;

namespace WebApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200608074834_UpdateModel2")]
    partial class UpdateModel2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi.Infrastructure.Models.ImageUrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ImageUrls");
                });

            modelBuilder.Entity("WebApi.Infrastructure.Models.PaymentDetail", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.Property<string>("CardOwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ExpirationDate")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.HasKey("PaymentId");

                    b.ToTable("PaymentDetails");
                });

            modelBuilder.Entity("WebApi.Infrastructure.Models.Producer", b =>
                {
                    b.Property<int>("ProducerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthBy")
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("AuthDate")
                        .HasColumnType("DateTime2");

                    b.Property<string>("AuthStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("DateTime2");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdateBy")
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("DateTime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProducerId");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("WebApi.Infrastructure.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthBy")
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("AuthDate")
                        .HasColumnType("DateTime2");

                    b.Property<string>("AuthStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("DateTime2");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdateBy")
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("DateTime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebApi.Infrastructure.Models.ImageUrl", b =>
                {
                    b.HasOne("WebApi.Infrastructure.Models.Product", "Product")
                        .WithMany("ImageUrls")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApi.Infrastructure.Models.Product", b =>
                {
                    b.HasOne("WebApi.Infrastructure.Models.Producer", "Producer")
                        .WithMany("Products")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}