﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NeagoeElizaProgramariStomatologie.Data;

#nullable disable

namespace NeagoeElizaProgramariStomatologie.Migrations
{
    [DbContext(typeof(NeagoeElizaProgramariStomatologieContext))]
    [Migration("20230117083119_SpecializariMedic5")]
    partial class SpecializariMedic5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NeagoeElizaProgramariStomatologie.Models.Medic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("NumeMedic")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PrenumeMedic")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("SpecializareID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SpecializareID");

                    b.ToTable("Medic");
                });

            modelBuilder.Entity("NeagoeElizaProgramariStomatologie.Models.Pacient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("NumePacient")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PrenumePacient")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TelefonPacient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Pacient");
                });

            modelBuilder.Entity("NeagoeElizaProgramariStomatologie.Models.Procedura", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("NumeProcedura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Procedura");
                });

            modelBuilder.Entity("NeagoeElizaProgramariStomatologie.Models.Programare", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ID"));

                    b.Property<DateTime?>("DataProgramare")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MedicID")
                        .HasColumnType("int");

                    b.Property<int?>("PacientID")
                        .HasColumnType("int");

                    b.Property<int?>("ProceduraID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MedicID");

                    b.HasIndex("PacientID");

                    b.HasIndex("ProceduraID");

                    b.ToTable("Programare");
                });

            modelBuilder.Entity("NeagoeElizaProgramariStomatologie.Models.Specializare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("NumeSpecializare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Specializare");
                });

            modelBuilder.Entity("NeagoeElizaProgramariStomatologie.Models.SpecializareMedic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("MedicID")
                        .HasColumnType("int");

                    b.Property<int>("SpecializareID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MedicID");

                    b.HasIndex("SpecializareID");

                    b.ToTable("SpecializareMedic");
                });

            modelBuilder.Entity("NeagoeElizaProgramariStomatologie.Models.Medic", b =>
                {
                    b.HasOne("NeagoeElizaProgramariStomatologie.Models.Specializare", "Specializare")
                        .WithMany("Medici")
                        .HasForeignKey("SpecializareID");

                    b.Navigation("Specializare");
                });

            modelBuilder.Entity("NeagoeElizaProgramariStomatologie.Models.Programare", b =>
                {
                    b.HasOne("NeagoeElizaProgramariStomatologie.Models.Medic", "Medic")
                        .WithMany("Programari")
                        .HasForeignKey("MedicID");

                    b.HasOne("NeagoeElizaProgramariStomatologie.Models.Pacient", "Pacient")
                        .WithMany("Programari")
                        .HasForeignKey("PacientID");

                    b.HasOne("NeagoeElizaProgramariStomatologie.Models.Procedura", "Procedura")
                        .WithMany("Programari")
                        .HasForeignKey("ProceduraID");

                    b.Navigation("Medic");

                    b.Navigation("Pacient");

                    b.Navigation("Procedura");
                });

            modelBuilder.Entity("NeagoeElizaProgramariStomatologie.Models.SpecializareMedic", b =>
                {
                    b.HasOne("NeagoeElizaProgramariStomatologie.Models.Medic", "Medic")
                        .WithMany("SpecializariMedic")
                        .HasForeignKey("MedicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NeagoeElizaProgramariStomatologie.Models.Specializare", "Specializare")
                        .WithMany()
                        .HasForeignKey("SpecializareID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medic");

                    b.Navigation("Specializare");
                });

            modelBuilder.Entity("NeagoeElizaProgramariStomatologie.Models.Medic", b =>
                {
                    b.Navigation("Programari");

                    b.Navigation("SpecializariMedic");
                });

            modelBuilder.Entity("NeagoeElizaProgramariStomatologie.Models.Pacient", b =>
                {
                    b.Navigation("Programari");
                });

            modelBuilder.Entity("NeagoeElizaProgramariStomatologie.Models.Procedura", b =>
                {
                    b.Navigation("Programari");
                });

            modelBuilder.Entity("NeagoeElizaProgramariStomatologie.Models.Specializare", b =>
                {
                    b.Navigation("Medici");
                });
#pragma warning restore 612, 618
        }
    }
}
