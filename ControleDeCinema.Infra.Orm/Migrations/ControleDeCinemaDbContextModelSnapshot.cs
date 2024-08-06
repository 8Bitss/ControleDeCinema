﻿// <auto-generated />
using System;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleDeCinema.Infra.Orm.Migrations
{
    [DbContext(typeof(ControleDeCinemaDbContext))]
    partial class ControleDeCinemaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ControleDeCinema.Dominio.ModuloFilme.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Duracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar (200)");

                    b.HasKey("Id");

                    b.ToTable("TBFilme", (string)null);
                });

            modelBuilder.Entity("ControleDeCinema.Dominio.ModuloFuncionario.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar (200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar (200)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar (200)");

                    b.HasKey("Id");

                    b.ToTable("TBFuncionario", (string)null);
                });

            modelBuilder.Entity("ControleDeCinema.Dominio.ModuloSala.Poltrona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Sala_Id")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Sala_Id");

                    b.ToTable("TBPoltrona", (string)null);
                });

            modelBuilder.Entity("ControleDeCinema.Dominio.ModuloSala.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<int>("QtdAssentosDisponiveis")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TBSala", (string)null);
                });

            modelBuilder.Entity("ControleDeCinema.Dominio.ModuloSala.Poltrona", b =>
                {
                    b.HasOne("ControleDeCinema.Dominio.ModuloSala.Sala", null)
                        .WithMany("Poltronas")
                        .HasForeignKey("Sala_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_TBSala_TBPoltrona");
                });

            modelBuilder.Entity("ControleDeCinema.Dominio.ModuloSala.Sala", b =>
                {
                    b.Navigation("Poltronas");
                });
#pragma warning restore 612, 618
        }
    }
}
