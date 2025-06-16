using Microsoft.EntityFrameworkCore;

namespace HastaneRandevu.Models
{
    public class HastaneContext : DbContext
    {
        public HastaneContext(DbContextOptions<HastaneContext> options) : base(options) { }

        public DbSet<Randevu> Randevular { get; set; }
    }
}