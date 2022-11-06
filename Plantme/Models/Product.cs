using Plantme.Data;
using System.ComponentModel.DataAnnotations;

namespace Plantme.Models
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; } 

        [Display(Name = "Plant Name")]

        [StringLength(100, ErrorMessage = "Plant name length exeeded, provide shorter name")]
        public string ProductName { get; set; }

        [Display(Name = "Price per unit")]

    
        public float ProductPrice { get; set; }

        [Display(Name = "Short description")]
        [StringLength(250, ErrorMessage = "Plant name length exeeded, provide shorter name")]

        public string Description { get; set; }

        [Display(Name = "Plant Type")]
        public ProductTypes ProductTypes { get; set; }

        [Display(Name = "Image")]
        public string ProductImage { get; set; }

        [Display(Name = "Difficulty Level")]
        public string DifficultyLevel { get; set; }


        [Display(Name = "Rating")]
        [Range(1,5,ErrorMessage = "Rate from 1 to 5") ]
        public int Rating { get; set; }

        [Display(Name = "Growing Conditions")]
        [StringLength(250, ErrorMessage = "Provide shorted description for growing conditions")]
        public string GrowingConditions { get; set; }

        [Display(Name = "Planting Instructions")]
        public string PlantingInstructions { get; set; }

        [Display(Name = "Pet Friendly")]
        public Boolean PetFriendly  { get; set; }

        [Display(Name = "Child Friendly")]
        public Boolean ChildFriendly { get; set; }

        [Display(Name = "Beginner Friendly")]
        public Boolean BeginnerFriendly { get; set; }

        [Display(Name = "Documentation")]
        public string Documentation { get; set; }

        public List<OrderItemInfo> OrderItemInfo { get; set; }

    }
}
