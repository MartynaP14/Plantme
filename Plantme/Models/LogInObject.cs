using System.ComponentModel.DataAnnotations;

namespace Plantme.Models
{
    public class LogInObject
    {
     
        public string LogInEmail { get; set; }
        [DataType(DataType.Password)]
        public string LogInPassword { get; set; }
        public bool RememberMe { get; set; }

        public string? ReturnPage { get; set; }
    }
}
