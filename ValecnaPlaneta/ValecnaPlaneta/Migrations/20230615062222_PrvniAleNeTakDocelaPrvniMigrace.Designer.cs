﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ValecnaPlaneta.Data;

#nullable disable

namespace ValecnaPlaneta.Migrations
{
    [DbContext(typeof(NasDbContext))]
    [Migration("20230615062222_PrvniAleNeTakDocelaPrvniMigrace")]
    partial class PrvniAleNeTakDocelaPrvniMigrace
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ValecnaPlaneta.Models.Hra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Heslo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Jmeno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Soukroma")
                        .HasColumnType("bit");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hry");
                });

            modelBuilder.Entity("ValecnaPlaneta.Models.Hrac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CasPosledniAkce")
                        .HasColumnType("datetime2");

                    b.Property<int>("HraKamPatriId")
                        .HasColumnType("int");

                    b.Property<int>("Kapital")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Zije")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("HraKamPatriId");

                    b.ToTable("Hraci");
                });

            modelBuilder.Entity("ValecnaPlaneta.Models.Policko", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HraKamPatriId")
                        .HasColumnType("int");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<int>("Stav")
                        .HasColumnType("int");

                    b.Property<string>("Vlastnik")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HraKamPatriId");

                    b.ToTable("Policka");
                });

            modelBuilder.Entity("ValecnaPlaneta.Models.Hrac", b =>
                {
                    b.HasOne("ValecnaPlaneta.Models.Hra", "HraKamPatri")
                        .WithMany("Hraci")
                        .HasForeignKey("HraKamPatriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HraKamPatri");
                });

            modelBuilder.Entity("ValecnaPlaneta.Models.Policko", b =>
                {
                    b.HasOne("ValecnaPlaneta.Models.Hra", "HraKamPatri")
                        .WithMany("Policka")
                        .HasForeignKey("HraKamPatriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HraKamPatri");
                });

            modelBuilder.Entity("ValecnaPlaneta.Models.Hra", b =>
                {
                    b.Navigation("Hraci");

                    b.Navigation("Policka");
                });
#pragma warning restore 612, 618
        }
    }
}
