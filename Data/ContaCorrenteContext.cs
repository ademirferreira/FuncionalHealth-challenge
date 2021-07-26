using FuncionalBank.Models;
using Microsoft.EntityFrameworkCore;

namespace FuncionalBank.Data
{
    public class ContaCorrenteContext : DbContext
    {
        public ContaCorrenteContext(DbContextOptions<ContaCorrenteContext> options)
            :base(options){}

        public DbSet<ContaCorrente> ContasCorrentes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContaCorrente>(contaCorrente =>
            {
                contaCorrente.HasIndex(x => x.Id);
                contaCorrente.HasAlternateKey(x => x.Numero);
            });
        }
    }
}