﻿// <auto-generated />
using MCON368CourseProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MCON368CourseProject.Migrations
{
    [DbContext(typeof(YeshivaContext))]
    [Migration("20230515172427_Initialize")]
    partial class Initialize
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("MCON368CourseProject.Rebbi", b =>
                {
                    b.Property<int>("RebbiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RebbiID");

                    b.ToTable("Rebbi");
                });

            modelBuilder.Entity("MCON368CourseProject.Shiur", b =>
                {
                    b.Property<int>("ShiurID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RebbiId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ShiurID");

                    b.HasIndex("RebbiId");

                    b.ToTable("Shiur");
                });

            modelBuilder.Entity("MCON368CourseProject.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ShiurID")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentID");

                    b.HasIndex("ShiurID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("MCON368CourseProject.Shiur", b =>
                {
                    b.HasOne("MCON368CourseProject.Rebbi", "Rebbi")
                        .WithMany("Shiurs")
                        .HasForeignKey("RebbiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rebbi");
                });

            modelBuilder.Entity("MCON368CourseProject.Student", b =>
                {
                    b.HasOne("MCON368CourseProject.Shiur", "Shiur")
                        .WithMany("Students")
                        .HasForeignKey("ShiurID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shiur");
                });

            modelBuilder.Entity("MCON368CourseProject.Rebbi", b =>
                {
                    b.Navigation("Shiurs");
                });

            modelBuilder.Entity("MCON368CourseProject.Shiur", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
