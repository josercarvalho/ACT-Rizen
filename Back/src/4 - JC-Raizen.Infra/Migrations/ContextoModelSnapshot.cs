﻿// <auto-generated />
using System;
using JC_Raizen.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JC_Raizen.Infra.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JC_Raizen.Domain.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataNascimento")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("datanascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("VARCHAR(180)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)")
                        .HasColumnName("nome");

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)")
                        .HasColumnName("bairro");

                    b.Property<string>("cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("VARCHAR(8)")
                        .HasColumnName("cep");

                    b.Property<string>("complemento")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("VARCHAR(180)")
                        .HasColumnName("complemento");

                    b.Property<string>("localidade")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)")
                        .HasColumnName("localidade");

                    b.Property<string>("logradouro")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)")
                        .HasColumnName("logradouro");

                    b.Property<string>("uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("VARCHAR(2)")
                        .HasColumnName("uf");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
