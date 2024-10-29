namespace ThAmCo.Catering.Data
{
    public class MenuFoodItem
    {
        //variables for MenuFoodItem class
        public int MenuId { get; set; }
        public int FoodItemID { get; set; }

        //Many to one relationship to FoodItem
        public FoodItem? FoodItem { get; set; }

        //Many to one relationship to Menu
        public Menu? Menu { get; set; }
    }
}
