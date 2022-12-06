using System.ComponentModel.DataAnnotations;

namespace Plantme.Models
{
    public class RegisterObject
    {

        public string UserLoginName { get; set; }
        public string UserEmail { get; set; }

        public string UserPhoneNo { get; set; }

        public string Location { get; set; }

        public string UserFirstName { get; set; }

        public string UserSurname { get; set; }

        public string Address { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string? ReturnPage { get; set; }

    }
}
