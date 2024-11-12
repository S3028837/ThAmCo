namespace ThAmCo.Catering.Dto
{
    public class MenuDetailsDto
    {
        public int MenuId { get;  set; }
        public string MenuName { get; set; }
        public List<FoodItemDto> Items { get; set; }
    }
}
