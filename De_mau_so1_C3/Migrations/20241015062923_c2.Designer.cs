﻿// <auto-generated />
using De_mau_so1_C3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace De_mau_so1_C3.Migrations
{
    [DbContext(typeof(AppDbcontextSv))]
    [Migration("20241015062923_c2")]
    partial class c2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("De_mau_so1_C3.Models.LopHoc", b =>
                {
                    b.Property<string>("MaLop")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Khoa")
                        .HasColumnType("int");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaLop");

                    b.ToTable("LopHocs");
                });

            modelBuilder.Entity("De_mau_so1_C3.Models.SinhVien", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaLop")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nganh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NgaySinh")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MaLop");

                    b.ToTable("SinhViens");
                });

            modelBuilder.Entity("De_mau_so1_C3.Models.SinhVien", b =>
                {
                    b.HasOne("De_mau_so1_C3.Models.LopHoc", "LopHoc")
                        .WithMany("SinhViens")
                        .HasForeignKey("MaLop")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LopHoc");
                });

            modelBuilder.Entity("De_mau_so1_C3.Models.LopHoc", b =>
                {
                    b.Navigation("SinhViens");
                });
#pragma warning restore 612, 618
        }
    }
}
