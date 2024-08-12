using Microsoft.EntityFrameworkCore;
using Bebidas_ML.Models;

namespace Bebidas_ML.Data
{
    public class BebidasDbContext : DbContext
    {
        public BebidasDbContext(DbContextOptions<BebidasDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bebida> Bebidas { get; set; }
        public DbSet<TipoBebida> TiposBebida { get; set; }
    }
}
