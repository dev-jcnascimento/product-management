﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductManagement.Infra.Persistence;

#nullable disable

namespace ProductManagement.Infra.Migrations
{
    [DbContext(typeof(ProductManagementContext))]
    [Migration("20220125182020_StockStatus")]
    partial class StockStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProductManagement.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Brand");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Description");

                    b.Property<string>("Model")
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("ProductManagement.Domain.Entities.Stock", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductId");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Status");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("Stock", (string)null);
                });

            modelBuilder.Entity("ProductManagement.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Role");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ProductManagement.Domain.Entities.Stock", b =>
                {
                    b.HasOne("ProductManagement.Domain.Entities.Product", "Product")
                        .WithMany("ProductStocks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductManagement.Domain.Entities.User", "User")
                        .WithMany("UserStocks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProductManagement.Domain.Entities.User", b =>
                {
                    b.OwnsOne("ProductManagement.Domain.ValueObject.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Webmail")
                                .IsRequired()
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("ProductManagement.Domain.ValueObject.Name", "Nome", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FistName")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("FistName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("LastName");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("ProductManagement.Domain.ValueObject.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Word")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Password");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email");

                    b.Navigation("Nome");

                    b.Navigation("Password");
                });

            modelBuilder.Entity("ProductManagement.Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductStocks");
                });

            modelBuilder.Entity("ProductManagement.Domain.Entities.User", b =>
                {
                    b.Navigation("UserStocks");
                });
#pragma warning restore 612, 618
        }
    }
}