using Microsoft.EntityFrameworkCore;
namespace ThAmCo.Catering.Data
{
    public class CateringDbContext: DbContext
    {
        //Defining the database tables
        public DbSet<FoodBooking> FoodBookings {  get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuFoodItem> MenuFoodItems { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }



        //tells program where to save db
        private string DbPath {  get; set; } = string.Empty;
        public CateringDbContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "thAmCo.catering.db");
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
            modelBuilder.Entity<FoodBooking>()
                .HasKey(ts => new { ts.FoodBookingId, ts.MenuId });
        }
    }
}
