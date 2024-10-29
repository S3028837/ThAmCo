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

            //Defifning primary keys
            modelBuilder.Entity<FoodBooking>()
                .HasKey(fb => fb.FoodBookingId);

            modelBuilder.Entity<Menu>()
                .HasKey(m => m.MenuID);

            modelBuilder.Entity<FoodItem>()
                .HasKey(fi => fi.FoodItemId);

            //defining composite key
            modelBuilder.Entity<MenuFoodItem>()
                .HasKey(mfi => new {mfi.MenuId, mfi.FoodItemID});

            //Defining relationships for compisite key
            modelBuilder.Entity<Menu>()
                .HasMany(mfi => mfi.MenuFoodItems)
                .WithOne(m => m.Menu)
                .HasForeignKey(m => m.MenuId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FoodItem>()
                .HasMany(mfi => mfi.MenuFoodItems)
                .WithOne(fi => fi.FoodItem)
                .OnDelete(DeleteBehavior.Restrict);
            //OnDelete prevents entries within table from being deleted

            //relationship between menu and foodBooking
            modelBuilder.Entity<Menu>()
                .HasMany(fb => fb.FoodBookings)
                .WithOne(m => m.Menu)
                .OnDelete(DeleteBehavior.Restrict);




        }
    }
}
