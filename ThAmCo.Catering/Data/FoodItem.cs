using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class FoodItem
    {
        //Variables for FoodItem class
        [Required]
        public int FoodItemId { get; set; }
        [MaxLength(50)]
        public string? Description { get; set; }
        public float? UnitPrice { get; set; }


        //one-to-many relationship to MenuFoodItems
        public MenuFoodItem? MenuFoodItem { get; set; }
    }
}
