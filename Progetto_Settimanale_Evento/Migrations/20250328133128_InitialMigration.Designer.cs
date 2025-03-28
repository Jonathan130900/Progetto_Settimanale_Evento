﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Progetto_Settimanale_Evento.Data;

#nullable disable

namespace Progetto_Settimanale_Evento.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250328133128_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Progetto_Settimanale_Evento.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("Progetto_Settimanale_Evento.Models.Artista", b =>
                {
                    b.Property<int>("ArtistaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistaId"));

                    b.Property<string>("Biografia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistaId");

                    b.ToTable("Artisti");
                });

            modelBuilder.Entity("Progetto_Settimanale_Evento.Models.Biglietto", b =>
                {
                    b.Property<int>("BigliettoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BigliettoId"));

                    b.Property<DateTime>("DataAcquisto")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BigliettoId");

                    b.HasIndex("EventoId");

                    b.HasIndex("UserId");

                    b.ToTable("Biglietti");
                });

            modelBuilder.Entity("Progetto_Settimanale_Evento.Models.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventoId"));

                    b.Property<int>("ArtistaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Luogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titolo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventoId");

                    b.HasIndex("ArtistaId");

                    b.ToTable("Eventi");
                });

            modelBuilder.Entity("Progetto_Settimanale_Evento.Models.Biglietto", b =>
                {
                    b.HasOne("Progetto_Settimanale_Evento.Models.Evento", "Evento")
                        .WithMany("Biglietti")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Progetto_Settimanale_Evento.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Progetto_Settimanale_Evento.Models.Evento", b =>
                {
                    b.HasOne("Progetto_Settimanale_Evento.Models.Artista", "Artista")
                        .WithMany("Eventi")
                        .HasForeignKey("ArtistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artista");
                });

            modelBuilder.Entity("Progetto_Settimanale_Evento.Models.Artista", b =>
                {
                    b.Navigation("Eventi");
                });

            modelBuilder.Entity("Progetto_Settimanale_Evento.Models.Evento", b =>
                {
                    b.Navigation("Biglietti");
                });
#pragma warning restore 612, 618
        }
    }
}
