﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiArt.Data;

#nullable disable

namespace WebApiArt.Data.ArtMigrations
{
    [DbContext(typeof(ArtContext))]
    partial class ArtContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.15");

            modelBuilder.Entity("WebApiArt.Models.ArtType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("ArtTypes");
                });

            modelBuilder.Entity("WebApiArt.Models.Artwork", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArtTypeID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Completed")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(511)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.HasIndex("ArtTypeID")
                        .IsUnique();

                    b.ToTable("Artworks");
                });

            modelBuilder.Entity("WebApiArt.Models.Artwork", b =>
                {
                    b.HasOne("WebApiArt.Models.ArtType", "ArtType")
                        .WithMany("Artworks")
                        .HasForeignKey("ArtTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArtType");
                });

            modelBuilder.Entity("WebApiArt.Models.ArtType", b =>
                {
                    b.Navigation("Artworks");
                });
#pragma warning restore 612, 618
        }
    }
}
