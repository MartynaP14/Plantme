namespace Plantme.Models
{
    public class BasketItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int ProductQuantity { get; set; }

        public float ProductPrice { get; set; }

        public string ProductImage { get; set; }

        public float Total
        {
            get { return ProductQuantity * ProductPrice; }

        }

        public BasketItem()
        {

        }


        public BasketItem(Product product)
        {
            ProductId = product.ProductId;
            ProductName = product.ProductName;
            ProductQuantity = 1;
            ProductPrice = product.ProductPrice;
            ProductImage = product.ProductImage;

        }
    }

}
