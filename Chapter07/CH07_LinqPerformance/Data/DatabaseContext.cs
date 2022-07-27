namespace CH07_LinqPerformance.Data
{
	using Microsoft.EntityFrameworkCore;
	using CH07_LinqPerformance.Models;

	public class DatabaseContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

        public DatabaseContext(string connectionString) : base(GetOptions(connectionString))
        {
          
		}

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .HasMaxLength(50);
                entity.Property(e => e.Description)
                    .HasMaxLength(255);
            });
        }
    }
}
