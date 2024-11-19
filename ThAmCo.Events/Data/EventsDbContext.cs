using Microsoft.EntityFrameworkCore;

namespace ThAmCo.Events.Data
{
    public class EventsDbContext : DbContext
    {
        //Db tables
        public DbSet<Event> Events { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<GuestBooking> GuestBookings { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Staffing> Staffings { get; set; }



        //tells program where to save db
        private string DbPath { get; set; } = string.Empty;
        public EventsDbContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "thAmCo.events.db");
        }



        //specifies that SQlite will be used
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source =" + DbPath);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .HasKey(e=>e.EventId);

            modelBuilder.Entity<Staff>()
                .HasKey(s=>s.StaffId);


            modelBuilder.Entity<Staffing>()
                .HasKey(st => new { st.StaffId, st.EventId });

            modelBuilder.Entity<Event>()
                .HasMany(st =>st.Staffings)
                .WithOne(e=>e.Event)
                .HasForeignKey(e=>e.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Staff>()
                .HasMany(st => st.Staffings)
                .WithOne(s => s.Staff)
                .HasForeignKey(s=>s.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>()
                .HasOne(gb => gb.GuestBooking)
                .WithOne(e => e.Event)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Guest>()
                .HasMany(gb => gb.GuestBookings)
                .WithOne(g => g.Guest)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
