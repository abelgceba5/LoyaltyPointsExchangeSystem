﻿// <auto-generated />
using System;
using LoyaltyPointsExchangeSystem.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Loyalty_Points_Exchange_System.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20240415214807_Initial_run")]
    partial class Initial_run
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LoyaltyPointsExchangeSystem.Models.Login", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoginId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginId");

                    b.ToTable("logins");
                });

            modelBuilder.Entity("LoyaltyPointsExchangeSystem.Models.RegisterUser", b =>
                {
                    b.Property<int>("RegisterUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegisterUserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegisterUserId");

                    b.ToTable("registerUsers");
                });

            modelBuilder.Entity("Loyalty_Points_Exchange_System.Models.EarnPoints", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EarnedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PointsEarned")
                        .HasColumnType("int");

                    b.Property<int>("RegisterUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("earnPoints");
                });

            modelBuilder.Entity("Loyalty_Points_Exchange_System.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("RegisteredUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("items");
                });

            modelBuilder.Entity("Loyalty_Points_Exchange_System.Models.LoyaltyPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RegisterUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("loyaltyPoints");
                });

            modelBuilder.Entity("Loyalty_Points_Exchange_System.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegisterUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("purchases");
                });

            modelBuilder.Entity("Loyalty_Points_Exchange_System.Models.RedeemPoints", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AmountRedeemed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PointsRedeemed")
                        .HasColumnType("int");

                    b.Property<DateTime>("RedeemedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RegisterUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("redeemPoints");
                });

            modelBuilder.Entity("Loyalty_Points_Exchange_System.Models.TransactionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AmountChanged")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PointsChanged")
                        .HasColumnType("int");

                    b.Property<int>("RegisterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("transactionHistories");
                });

            modelBuilder.Entity("Loyalty_Points_Exchange_System.Models.TransferToBank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PointsTransferred")
                        .HasColumnType("int");

                    b.Property<int>("RegisterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransferDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("transferToBanks");
                });

            modelBuilder.Entity("Loyalty_Points_Exchange_System.Models.TransferToUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FromUserId")
                        .HasColumnType("int");

                    b.Property<int>("PointsTransferred")
                        .HasColumnType("int");

                    b.Property<int>("ToUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransferDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TransferToUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
