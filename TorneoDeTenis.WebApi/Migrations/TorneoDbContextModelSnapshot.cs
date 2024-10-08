﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TorneoDeTenis.WebApi.Infraestructure.Data;

#nullable disable

namespace TorneoDeTenis.WebApi.Migrations
{
    [DbContext(typeof(TorneoDbContext))]
    partial class TorneoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TorneoDeTenis.WebApi.Models.Enfrentamiento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<long?>("GanadorId")
                        .HasColumnType("bigint");

                    b.Property<int>("NumeroDeRonda")
                        .HasColumnType("int");

                    b.Property<int>("TipoTorneo")
                        .HasColumnType("int");

                    b.Property<long?>("TorneoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GanadorId");

                    b.HasIndex("TorneoId");

                    b.ToTable("Enfrentamiento");

                    b.HasDiscriminator().HasValue("Enfrentamiento");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TorneoDeTenis.WebApi.Models.Jugador", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Fuerza")
                        .HasColumnType("int");

                    b.Property<int>("Habilidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TiempoReaccion")
                        .HasColumnType("int");

                    b.Property<int>("Velocidad")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Jugadores");
                });

            modelBuilder.Entity("TorneoDeTenis.WebApi.Models.Partido", b =>
                {
                    b.HasBaseType("TorneoDeTenis.WebApi.Models.Enfrentamiento");

                    b.Property<long>("PrimerJugadorId")
                        .HasColumnType("bigint");

                    b.Property<long>("SegundoJugadorId")
                        .HasColumnType("bigint");

                    b.HasIndex("PrimerJugadorId");

                    b.HasIndex("SegundoJugadorId");

                    b.HasDiscriminator().HasValue("Partido");
                });

            modelBuilder.Entity("TorneoDeTenis.WebApi.Models.Torneo", b =>
                {
                    b.HasBaseType("TorneoDeTenis.WebApi.Models.Enfrentamiento");

                    b.HasDiscriminator().HasValue("Torneo");
                });

            modelBuilder.Entity("TorneoDeTenis.WebApi.Models.Enfrentamiento", b =>
                {
                    b.HasOne("TorneoDeTenis.WebApi.Models.Jugador", "Ganador")
                        .WithMany()
                        .HasForeignKey("GanadorId");

                    b.HasOne("TorneoDeTenis.WebApi.Models.Torneo", null)
                        .WithMany("Enfrentamientos")
                        .HasForeignKey("TorneoId");

                    b.Navigation("Ganador");
                });

            modelBuilder.Entity("TorneoDeTenis.WebApi.Models.Partido", b =>
                {
                    b.HasOne("TorneoDeTenis.WebApi.Models.Jugador", "PrimerJugador")
                        .WithMany()
                        .HasForeignKey("PrimerJugadorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TorneoDeTenis.WebApi.Models.Jugador", "SegundoJugador")
                        .WithMany()
                        .HasForeignKey("SegundoJugadorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PrimerJugador");

                    b.Navigation("SegundoJugador");
                });

            modelBuilder.Entity("TorneoDeTenis.WebApi.Models.Torneo", b =>
                {
                    b.Navigation("Enfrentamientos");
                });
#pragma warning restore 612, 618
        }
    }
}
