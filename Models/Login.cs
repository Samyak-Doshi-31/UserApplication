using System.ComponentModel.DataAnnotations;

namespace UserApplication.Models
{
    public class Login
    {
        [Required]
        [RegularExpression("(^[6-9][0-9]{9}$)", ErrorMessage = "Invalid Mobile Number")]
        public string UserMobileNumber { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}
