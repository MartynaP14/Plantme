namespace Plantme.Models
{
    public class ShoppingBasket
    {
        public int NumberOfProdcuts { get; set; }

        public List<BasketItem> BasketItems { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
