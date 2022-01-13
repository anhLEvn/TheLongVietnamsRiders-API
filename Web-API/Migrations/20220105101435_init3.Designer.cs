﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_API.Models;

namespace Web_API.Migrations
{
    [DbContext(typeof(TLVNRsDBContext))]
    [Migration("20220105101435_init3")]
    partial class init3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Web_API.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UlrImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Web_API.Models.Tour", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionTour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItineraryFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LengthTour")
                        .HasColumnType("int");

                    b.Property<int>("MaxParticipant")
                        .HasColumnType("int");

                    b.Property<int>("MinParticipant")
                        .HasColumnType("int");

                    b.Property<string>("NameTour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PriceTour")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("Web_API.Models.TourPackage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DescriptionTour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItineraryUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameTour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PriceTour")
                        .HasColumnType("real");

                    b.Property<int>("TimeTour")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TourPackages");
                });
#pragma warning restore 612, 618
        }
    }
}
