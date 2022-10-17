using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plantme.Models
{
    public class OrderItemInfo
    {
        [Key]
        public int OrderItemInfoId { get; set; }

        public int ProductOrderID { get; set; }
        [ForeignKey("ProductOrderID")]
        public ProductOrder ProductOrder { get; set; }


        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }


    }
}
