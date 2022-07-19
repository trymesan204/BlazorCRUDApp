using BlazorCRUDapp.Shared;

namespace BlazorCRUDapp.Server.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket {id = 1, Name = "Sagarmatha", start = "Kathmandu", destination = "Birgunj", time = "8pm"},
                new Ticket {id = 2, Name = "Lantang", start = "Kathmandu", destination = "Rautahat", time = "7pm"}
            );
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlite("Data Source="+DbPath);
        // }

        public DbSet<Ticket> Tickets { get; set; }

        public static string DbPath = "Ticket.db";

    }
}