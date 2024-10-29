using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class Menu
    {
        //variables for menu class
        [Required]
        public int MenuID { get; set; }
        [MaxLength(50)]
        public string MenuName { get; set; }

        //one-to-many relationship to MenuFoodItem
        public List<MenuFoodItem>? MenuFoodItems { get; set; }
        //one to many relationship to FoodBooking
        public List<FoodBooking>? FoodBookings { get; set; }
    }
}
