﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220315140458_SubjectsUpd")]
    partial class SubjectsUpd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication1.Models.Group", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupID"), 1L, 1);

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("GroupID");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("WebApplication1.Models.Record", b =>
                {
                    b.Property<int>("RecordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecordID"), 1L, 1);

                    b.Property<string>("Auditorium")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("Teacher")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("RecordID");

                    b.HasIndex("SubjectId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("WebApplication1.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"), 1L, 1);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("SubjectId");

                    b.HasIndex("GroupId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Permission")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication1.Models.Record", b =>
                {
                    b.HasOne("WebApplication1.Models.Subject", "Subject")
                        .WithMany("Records")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("WebApplication1.Models.Subject", b =>
                {
                    b.HasOne("WebApplication1.Models.Group", "Group")
                        .WithMany("Subjects")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("WebApplication1.Models.Group", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("WebApplication1.Models.Subject", b =>
                {
                    b.Navigation("Records");
                });
#pragma warning restore 612, 618
        }
    }
}