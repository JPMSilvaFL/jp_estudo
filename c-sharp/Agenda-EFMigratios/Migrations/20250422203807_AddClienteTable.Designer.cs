﻿// <auto-generated />
using System;
using Agenda_EFMigratios.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Agenda_EFMigratios.Migrations
{
    [DbContext(typeof(AgendaDataContext))]
    [Migration("20250422203807_AddClienteTable")]
    partial class AddClienteTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Agenda_EFMigratios.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedAt");

                    b.Property<Guid>("PessoaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdPerson");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("Agenda_EFMigratios.Models.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UniqueIdentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("Contato");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar")
                        .HasColumnName("Cpf");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar")
                        .HasColumnName("Endereco");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar")
                        .HasColumnName("NomeCompleto");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("IsActive");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdatedAt");

                    b.Property<DateTime>("dataHoraLancamento")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Pessoa", (string)null);
                });

            modelBuilder.Entity("Agenda_EFMigratios.Models.Cliente", b =>
                {
                    b.HasOne("Agenda_EFMigratios.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });
#pragma warning restore 612, 618
        }
    }
}
