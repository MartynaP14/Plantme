using System.ComponentModel.DataAnnotations;

namespace Plantme.Data
{
    public enum ProductTypes
    {
        [Display(Name = "Flowering")]
        Flowering,

        Foliage,
        Cacti,
        IndoorPalms, 
        Trailing, 
        CommonHouse,
        IndoorTrees, 
    }
}
