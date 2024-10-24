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
        public MenuFoodItem? MenuFoodItem { get; set; }
        //one to many relationship to FoodBooking
        public FoodBooking? FoodBooking { get; set; }
    }
}
