﻿// <auto-generated />
using EmartProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmartProject.Migrations.Product
{
    [DbContext(typeof(ProductContext))]
    [Migration("20200204034618_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmartProject.Models.Product", b =>
                {
                    b.Property<int>("i_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("c_id")
                        .HasColumnType("int");

                    b.Property<string>("c_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("gst")
                        .HasColumnType("int");

                    b.Property<string>("i_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int>("s_id")
                        .HasColumnType("int");

                    b.Property<int>("stk_num")
                        .HasColumnType("int");

                    b.Property<int>("sub_id")
                        .HasColumnType("int");

                    b.Property<string>("sub_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("i_id");

                    b.ToTable("products");
                });
#pragma warning restore 612, 618
        }
    }
}
