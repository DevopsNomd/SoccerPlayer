using Microsoft.EntityFrameworkCore;

namespace SoccerPlayer.Models
{
    public  class SampleDatabaseContext:DbContext
    {
        public SampleDatabaseContext()
        {
            
        }
        public SampleDatabaseContext(DbContextOptions<SampleDatabaseContext>options)
            :base(options) { }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Player1> Players1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseSqlServer("Data Source = DESKTOP-L7S1A7N\\NOMD_DATA_SERVER; Initial Catalog=SampleDatabase;User ID=sa;password=Nomd@123;MultipleActiveResultSets=True;TrustServerCertificate=True");
    }
}
