using Demo.Prova.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using Demo.Prova.Core.Entities;

namespace Demo.Prova.Infra.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<Moedas> Moeda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Moedas>(new MoedasMap().Configure);
        }
    }
}
