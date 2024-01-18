﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using JC_Raizen.Domain.Entidades;

namespace JC_Raizen.Infra.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("INT");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("nome")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.DataNascimento)
                .IsRequired()
                .HasColumnName("password")
                .HasColumnType("datetime2");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(180)");

            builder.Property(x => x.CEP)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnName("cep")
                .HasColumnType("VARCHAR(8)");
        }
    }
}
