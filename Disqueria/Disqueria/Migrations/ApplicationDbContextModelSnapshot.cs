﻿// <auto-generated />
using System;
using Disqueria.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Disqueria.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Disqueria.Models.Artista", b =>
                {
                    b.Property<int>("ArtistaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GeneroID");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("Artista")
                        .HasMaxLength(100);

                    b.HasKey("ArtistaID");

                    b.HasIndex("GeneroID");

                    b.ToTable("Artistas");
                });

            modelBuilder.Entity("Disqueria.Models.Cancion", b =>
                {
                    b.Property<int>("CancionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DiscoID");

                    b.Property<string>("Duracion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("Cancion")
                        .HasMaxLength(100);

                    b.HasKey("CancionID");

                    b.HasIndex("DiscoID");

                    b.ToTable("Canciones");
                });

            modelBuilder.Entity("Disqueria.Models.Disco", b =>
                {
                    b.Property<int>("DiscoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArtistaID");

                    b.Property<int>("DiscograficaID");

                    b.Property<int>("GeneroID");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnName("Disco")
                        .HasMaxLength(100);

                    b.HasKey("DiscoID");

                    b.HasIndex("ArtistaID");

                    b.HasIndex("DiscograficaID");

                    b.HasIndex("GeneroID");

                    b.ToTable("Discos");
                });

            modelBuilder.Entity("Disqueria.Models.Discografica", b =>
                {
                    b.Property<int>("DiscograficaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("Discografica")
                        .HasMaxLength(100);

                    b.HasKey("DiscograficaID");

                    b.ToTable("Discograficas");
                });

            modelBuilder.Entity("Disqueria.Models.Genero", b =>
                {
                    b.Property<int>("GeneroID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("Genero");

                    b.HasKey("GeneroID");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("Disqueria.Models.Artista", b =>
                {
                    b.HasOne("Disqueria.Models.Genero", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Disqueria.Models.Cancion", b =>
                {
                    b.HasOne("Disqueria.Models.Disco")
                        .WithMany("ListaCanciones")
                        .HasForeignKey("DiscoID");
                });

            modelBuilder.Entity("Disqueria.Models.Disco", b =>
                {
                    b.HasOne("Disqueria.Models.Artista", "Artista")
                        .WithMany()
                        .HasForeignKey("ArtistaID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Disqueria.Models.Discografica", "Discografica")
                        .WithMany()
                        .HasForeignKey("DiscograficaID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Disqueria.Models.Genero", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
