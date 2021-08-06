﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test;

namespace Test.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Test.Assessment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContractId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("Test.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContractId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Test.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("Test.Signatory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Signatory");
                });

            modelBuilder.Entity("Test.Assessment", b =>
                {
                    b.HasOne("Test.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId");

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("Test.Company", b =>
                {
                    b.HasOne("Test.Contract", null)
                        .WithMany("Companies")
                        .HasForeignKey("ContractId");
                });

            modelBuilder.Entity("Test.Signatory", b =>
                {
                    b.HasOne("Test.Company", null)
                        .WithMany("Signatories")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Test.Company", b =>
                {
                    b.Navigation("Signatories");
                });

            modelBuilder.Entity("Test.Contract", b =>
                {
                    b.Navigation("Companies");
                });
#pragma warning restore 612, 618
        }
    }
}
