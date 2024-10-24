namespace ThAmCo.Catering.Data
{
    public class MenuFoodItem
    {
        //variables for MenuFoodItem class
        public int MenuId { get; set; }
        public int FoodItemID { get; set; }

        //Many to one relationship to FoodItem
        public List<FoodItem>? FoodItems { get; set; }

        //Many to one relationship to Menu
        public List<Menu>? Menus { get; set; }
    }
}
