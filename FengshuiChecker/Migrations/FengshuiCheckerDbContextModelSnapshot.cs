﻿// <auto-generated />
using System;
using FengshuiChecker.Console.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FengshuiChecker.Migrations
{
    [DbContext(typeof(FengshuiCheckerDbContext))]
    partial class FengshuiCheckerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FengshuiChecker.Models.PhoneNetworkProvider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PhoneNetworkProviders");
                });

            modelBuilder.Entity("FengshuiChecker.Models.PhoneNumber", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PhoneNumberPrefixId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumberPrefixId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("FengshuiChecker.Models.PhoneNumberPrefix", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PhoneNetworkProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNetworkProviderId");

                    b.ToTable("PhoneNumberPrefixes");
                });

            modelBuilder.Entity("FengshuiChecker.Models.PhoneNumber", b =>
                {
                    b.HasOne("FengshuiChecker.Models.PhoneNumberPrefix", "PhoneNumberPrefix")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PhoneNumberPrefixId");

                    b.Navigation("PhoneNumberPrefix");
                });

            modelBuilder.Entity("FengshuiChecker.Models.PhoneNumberPrefix", b =>
                {
                    b.HasOne("FengshuiChecker.Models.PhoneNetworkProvider", null)
                        .WithMany("PhoneNumberPrefixes")
                        .HasForeignKey("PhoneNetworkProviderId");
                });

            modelBuilder.Entity("FengshuiChecker.Models.PhoneNetworkProvider", b =>
                {
                    b.Navigation("PhoneNumberPrefixes");
                });

            modelBuilder.Entity("FengshuiChecker.Models.PhoneNumberPrefix", b =>
                {
                    b.Navigation("PhoneNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
