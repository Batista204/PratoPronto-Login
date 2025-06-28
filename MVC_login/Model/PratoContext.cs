using System.Data.Entity;

namespace PratoPronto.Models
{
    public class PratoContext : DbContext
    {
        public DbSet<Prato> Pratos { get; set; }
    }
}
