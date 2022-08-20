using Plantme.Data;
using System.ComponentModel.DataAnnotations;

namespace Plantme.Models
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; } 

        public string ProductName { get; set; }
        public float ProductPrice { get; set; }  

        public string Description { get; set; }

        public ProductTypes ProdcutTypes { get; set; }

        public float ProductSize { get; set; }

        public int ProductCount { get; set; }

        public string ProductImage { get; set; }

        public string DifficultyLevel { get; set; }

        public int Rating { get; set; }

        public string GrowingConditions { get; set; }

        public string PlantingInstructions { get; set; }

        public Boolean PetFriendly  { get; set; }

        public Boolean ChildFriendly { get; set; }

        public Boolean BeginnerFriendly { get; set; }

        public string Documentation { get; set; }

    }
}
