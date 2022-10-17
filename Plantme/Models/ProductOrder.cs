using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plantme.Models
{
    public class ProductOrder
    {
        [Key]
        public int ProductOrderID {get;set;}

        public DateTime OrderDateTime { get; set; }

        public int OrderQuantity {get;set;}

        public int OrderSubtotal {get;set;}

       

        //Product
        public string Id {get;set;}
        [ForeignKey("Id")]

        public User User {get;set;}

        public List<OrderItemInfo> OrderItemInfo { get; set; }



    }
}
