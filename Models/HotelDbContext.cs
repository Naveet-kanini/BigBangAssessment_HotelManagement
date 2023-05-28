using Microsoft.EntityFrameworkCore;

namespace BingBangAssessment_HotelManagement.Models
{
    public class HotelDbContext:DbContext
    {
        public HotelDbContext(DbContextOptions options):base(options) { }
        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Rooms> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotels>().HasMany(Hotels => Hotels.Rooms).WithOne(Rooms => Rooms.Hotels).HasForeignKey(Rooms=>Rooms.HID);
        }
    }
}
