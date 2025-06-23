namespace Basket.Api.Models
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public decimal TotalPrice { get; set; } = default!;

        public ShoppingCart(string username)
        {
            UserName = username;
        }

        //required for mapping
        public ShoppingCart()
        {
        }
    }
}
