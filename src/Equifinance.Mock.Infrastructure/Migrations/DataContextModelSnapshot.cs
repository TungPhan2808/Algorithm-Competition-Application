﻿// <auto-generated />
using System;
using Equifinance.Mock.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Equifinance.Mock.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Equifinance.Mock.API.Models.Problem", b =>
                {
                    b.Property<int>("ProblemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProblemID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ProblemID");

                    b.HasIndex("UserID");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("Equifinance.Mock.API.Models.Submission", b =>
                {
                    b.Property<int>("SubmissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubmissionID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProblemID")
                        .HasColumnType("int");

                    b.Property<string>("SubmittedCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("SubmissionID");

                    b.HasIndex("ProblemID");

                    b.HasIndex("UserID");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("Equifinance.Mock.API.Models.TestCase", b =>
                {
                    b.Property<int>("TestCaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestCaseID"));

                    b.Property<string>("ExpectedOutput")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Input")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemoryLimit")
                        .HasColumnType("int");

                    b.Property<int>("ProblemID")
                        .HasColumnType("int");

                    b.Property<int>("TimeLimit")
                        .HasColumnType("int");

                    b.HasKey("TestCaseID");

                    b.HasIndex("ProblemID");

                    b.ToTable("Testcases");
                });

            modelBuilder.Entity("Equifinance.Mock.API.Models.TestResult", b =>
                {
                    b.Property<int>("TestResultID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestResultID"));

                    b.Property<string>("ActualOutput")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExecutionTime")
                        .HasColumnType("int");

                    b.Property<int>("Memory")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubmissionID")
                        .HasColumnType("int");

                    b.Property<int>("TestCaseID")
                        .HasColumnType("int");

                    b.HasKey("TestResultID");

                    b.HasIndex("SubmissionID");

                    b.HasIndex("TestCaseID");

                    b.ToTable("TestResults");
                });

            modelBuilder.Entity("Equifinance.Mock.API.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfProblemSolved")
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Equifinance.Mock.API.Models.Problem", b =>
                {
                    b.HasOne("Equifinance.Mock.API.Models.User", "User")
                        .WithMany("Problems")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Equifinance.Mock.API.Models.Submission", b =>
                {
                    b.HasOne("Equifinance.Mock.API.Models.Problem", "Problem")
                        .WithMany("Submissions")
                        .HasForeignKey("ProblemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Equifinance.Mock.API.Models.User", "User")
                        .WithMany("Submissions")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Problem");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Equifinance.Mock.API.Models.TestCase", b =>
                {
                    b.HasOne("Equifinance.Mock.API.Models.Problem", "Problem")
                        .WithMany()
                        .HasForeignKey("ProblemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Problem");
                });

            modelBuilder.Entity("Equifinance.Mock.API.Models.TestResult", b =>
                {
                    b.HasOne("Equifinance.Mock.API.Models.Submission", "Submission")
                        .WithMany("TestResults")
                        .HasForeignKey("SubmissionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Equifinance.Mock.API.Models.TestCase", "TestCase")
                        .WithMany("TestResults")
                        .HasForeignKey("TestCaseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Submission");

                    b.Navigation("TestCase");
                });

            modelBuilder.Entity("Equifinance.Mock.API.Models.Problem", b =>
                {
                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("Equifinance.Mock.API.Models.Submission", b =>
                {
                    b.Navigation("TestResults");
                });

            modelBuilder.Entity("Equifinance.Mock.API.Models.TestCase", b =>
                {
                    b.Navigation("TestResults");
                });

            modelBuilder.Entity("Equifinance.Mock.API.Models.User", b =>
                {
                    b.Navigation("Problems");

                    b.Navigation("Submissions");
                });
#pragma warning restore 612, 618
        }
    }
}
