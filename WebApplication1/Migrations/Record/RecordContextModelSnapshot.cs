﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

namespace WebApplication1.Migrations.Record
{
    [DbContext(typeof(RecordContext))]
    partial class RecordContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Record", b =>
                {
                    b.Property<int>("RecordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Auditorium")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Group")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Teacher")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("RecordID");

                    b.ToTable("Records");
                });
#pragma warning restore 612, 618
        }
    }
}
