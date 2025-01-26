﻿// <auto-generated />
using System;
using Mapping_one_to_Many.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mapping_one_to_Many.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20250126064705_update1")]
    partial class update1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Mapping_one_to_Many.Model.Entity.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Street_address")
                        .HasColumnType("text");

                    b.Property<int?>("Zip_code")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Mapping_one_to_Many.Model.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Phone")
                        .HasColumnType("integer");

                    b.Property<decimal>("Salary")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Mapping_one_to_Many.Model.Entity.Address", b =>
                {
                    b.HasOne("Mapping_one_to_Many.Model.Entity.Employee", "Employee")
                        .WithMany("Addresses")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Mapping_one_to_Many.Model.Entity.Employee", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
