﻿// <auto-generated />
using System;
using EmployeeManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeManagement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241224105504_typeAdd")]
    partial class typeAdd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeManagement.Data.Entity.Emp.EmployeeInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("departmentId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("NVARCHAR(150)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("joiningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("NVARCHAR(200)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("position")
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("updatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("departmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeManagement.Data.Entity.Emp.PerformanceReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("reviewDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("score")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("updatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("employeeId");

                    b.ToTable("PerformanceReviews");
                });

            modelBuilder.Entity("EmployeeManagement.Data.Entity.MasterData.DepartmentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("budget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("departmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<int?>("managerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("updatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("managerId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EmployeeManagement.Data.Entity.Emp.EmployeeInfo", b =>
                {
                    b.HasOne("EmployeeManagement.Data.Entity.MasterData.DepartmentInfo", "department")
                        .WithMany()
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("department");
                });

            modelBuilder.Entity("EmployeeManagement.Data.Entity.Emp.PerformanceReview", b =>
                {
                    b.HasOne("EmployeeManagement.Data.Entity.Emp.EmployeeInfo", "employee")
                        .WithMany()
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");
                });

            modelBuilder.Entity("EmployeeManagement.Data.Entity.MasterData.DepartmentInfo", b =>
                {
                    b.HasOne("EmployeeManagement.Data.Entity.Emp.EmployeeInfo", "manager")
                        .WithMany()
                        .HasForeignKey("managerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("manager");
                });
#pragma warning restore 612, 618
        }
    }
}
