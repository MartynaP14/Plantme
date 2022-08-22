using System.ComponentModel.DataAnnotations.Schema;

namespace Plantme.Models
{
    public class ProductOrder
    {

        public int ProductOrderID {get;set;}

        public DateTime OrderDateTime { get; set; }

        public int OrderQuantity {get;set;}

        public int OrderSubtotal {get;set;}

       

        //Product
        public int ProductId {get;set;}
        [ForeignKey("ProductId")]

        public Product Product {get;set;}





    }
}
