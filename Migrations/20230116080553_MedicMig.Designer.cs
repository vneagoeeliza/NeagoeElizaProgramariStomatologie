// <auto-generated />
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
    [Migration("20230116080553_Medic")]
    partial class Medic
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
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ID"));

                    b.Property<string>("NumeMedic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrenumeMedic")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrenumePacient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("NeagoeElizaProgramariStomatologie.Models.Medic", b =>
                {
                    b.HasOne("NeagoeElizaProgramariStomatologie.Models.Specializare", "Specializare")
                        .WithMany("Medici")
                        .HasForeignKey("SpecializareID");

                    b.Navigation("Specializare");
                });

            modelBuilder.Entity("NeagoeElizaProgramariStomatologie.Models.Specializare", b =>
                {
                    b.Navigation("Medici");
                });
#pragma warning restore 612, 618
        }
    }
}
