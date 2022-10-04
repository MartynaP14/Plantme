using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Plantme.Models
{
    public class User : IdentityUser
    {
       
        /*public int UserId { get; set; } */

        public string UserLoginName { get; set; }
        public string UserEmail { get; set; }

        public int UserPhoneNo { get; set; }
        
        public string Location { get; set; }

        public string UserFirstName { get; set; }

        public string UserSurname { get; set; }

        public string Address { get; set; }

        //Database tables connection
        public List<Product> Products { get; set; }
      
    }
}
