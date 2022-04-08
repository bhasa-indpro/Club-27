﻿// <auto-generated />
using System;
using Club_27.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Club_27.Migrations
{
    [DbContext(typeof(Club27DBContext))]
    [Migration("20220323110058_MIGRATION2")]
    partial class MIGRATION2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Club_27.Models.ActivityMaster", b =>
                {
                    b.Property<int>("ActivityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActivityID"), 1L, 1);

                    b.Property<string>("ActivityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActivityID");

                    b.ToTable("ActivityMasters");
                });

            modelBuilder.Entity("Club_27.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentID"), 1L, 1);

                    b.Property<int>("ActivityID")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("ActivityID");

                    b.HasIndex("EmployeeID", "ActivityID")
                        .IsUnique();

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("Club_27.Models.EmployeeMaster", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID");

                    b.ToTable("EmployeeMasters");
                });

            modelBuilder.Entity("Club27.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Club_27.Models.Enrollment", b =>
                {
                    b.HasOne("Club_27.Models.ActivityMaster", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Club_27.Models.EmployeeMaster", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Club27.Models.User", b =>
                {
                    b.HasOne("Club_27.Models.EmployeeMaster", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID");

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
