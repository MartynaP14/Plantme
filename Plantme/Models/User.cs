using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Plantme.Models
{
    public class User : IdentityUser
    {
        
        

        
        public string Location { get; set; }

        public string UserFirstName { get; set; }

        public string UserSurname { get; set; }

        public string Address { get; set; }

        //Database tables connection
        public List<ProductOrder> ProductOrder { get; set; }
      
    }
}
