﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using back.Data;

#nullable disable

namespace back.Migrations
{
    [DbContext(typeof(DataContex))]
    [Migration("20230306111133_UpdateForPossiblePosition")]
    partial class UpdateForPossiblePosition
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeJobPosition", b =>
                {
                    b.Property<int>("PossibleEmployeePositionId")
                        .HasColumnType("int");

                    b.Property<int>("PossibleEmployeePositionId1")
                        .HasColumnType("int");

                    b.HasKey("PossibleEmployeePositionId", "PossibleEmployeePositionId1");

                    b.HasIndex("PossibleEmployeePositionId1");

                    b.ToTable("EmployeeJobPosition");
                });

            modelBuilder.Entity("back.Entities.Bonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("BonusDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Bonus");
                });

            modelBuilder.Entity("back.Entities.Deducation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DeducationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Deducation");
                });

            modelBuilder.Entity("back.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BossId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VacationDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BossId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("back.Entities.EmployeePosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("JobPositionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("JobPositionId");

                    b.ToTable("EmployeePosition");
                });

            modelBuilder.Entity("back.Entities.JobPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PositionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobPosition");
                });

            modelBuilder.Entity("back.Entities.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Salary");
                });

            modelBuilder.Entity("EmployeeJobPosition", b =>
                {
                    b.HasOne("back.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("PossibleEmployeePositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("back.Entities.JobPosition", null)
                        .WithMany()
                        .HasForeignKey("PossibleEmployeePositionId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("back.Entities.Bonus", b =>
                {
                    b.HasOne("back.Entities.Employee", "Employee")
                        .WithMany("Bonuses")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("back.Entities.Deducation", b =>
                {
                    b.HasOne("back.Entities.Employee", "Employee")
                        .WithMany("Deducations")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("back.Entities.Employee", b =>
                {
                    b.HasOne("back.Entities.Employee", "Boss")
                        .WithMany()
                        .HasForeignKey("BossId");

                    b.Navigation("Boss");
                });

            modelBuilder.Entity("back.Entities.EmployeePosition", b =>
                {
                    b.HasOne("back.Entities.Employee", "Employee")
                        .WithMany("EmployeePositions")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("back.Entities.JobPosition", "JobPosition")
                        .WithMany("EmployeePositions")
                        .HasForeignKey("JobPositionId");

                    b.Navigation("Employee");

                    b.Navigation("JobPosition");
                });

            modelBuilder.Entity("back.Entities.Salary", b =>
                {
                    b.HasOne("back.Entities.Employee", "Employee")
                        .WithMany("Salaries")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("back.Entities.Employee", b =>
                {
                    b.Navigation("Bonuses");

                    b.Navigation("Deducations");

                    b.Navigation("EmployeePositions");

                    b.Navigation("Salaries");
                });

            modelBuilder.Entity("back.Entities.JobPosition", b =>
                {
                    b.Navigation("EmployeePositions");
                });
#pragma warning restore 612, 618
        }
    }
}
