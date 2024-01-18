using JC_Raizen.Domain.Entidades;
using JC_Raizen.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace JC_Raizen.Infra.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public virtual DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClienteMap());
        }
    }
}
