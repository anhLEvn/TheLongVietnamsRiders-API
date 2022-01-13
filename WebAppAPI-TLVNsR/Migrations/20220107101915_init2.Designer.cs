﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppAPI_TLVNsR.DataContext;

namespace WebAppAPI_TLVNsR.Migrations
{
    [DbContext(typeof(TLVNsRsDBContext))]
    [Migration("20220107101915_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAppAPI_TLVNsR.Models.Tour", b =>
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

                    b.Property<float>("PriceTour")
                        .HasColumnType("real");

                    b.Property<string>("TitleTour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TourCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TourCategoryId");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("WebAppAPI_TLVNsR.Models.TourCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvatarImageFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionCate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameCategory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TourCategories");
                });

            modelBuilder.Entity("WebAppAPI_TLVNsR.Models.Tour", b =>
                {
                    b.HasOne("WebAppAPI_TLVNsR.Models.TourCategory", "TourCategory")
                        .WithMany("Tours")
                        .HasForeignKey("TourCategoryId");

                    b.Navigation("TourCategory");
                });

            modelBuilder.Entity("WebAppAPI_TLVNsR.Models.TourCategory", b =>
                {
                    b.Navigation("Tours");
                });
#pragma warning restore 612, 618
        }
    }
}
