namespace Plantme.Models
{
    public class BasketItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int ProdcutQuantity { get; set; }

        public float ProductPrice { get; set; }

        public float Total
        {
            get { return ProdcutQuantity * ProductPrice; }

        }


        public BasketItem(Product prodcut)
        {
            ProductId = prodcut.ProductId;
            ProductName = prodcut.ProductName;
            ProdcutQuantity = 1;
            ProductPrice = prodcut.ProductPrice;

            //Add image later 
        }
    }

}
