using System.ComponentModel.DataAnnotations;

namespace UserApplication.Models
{
    public class Register
    {
        [Key]
        public int UserRegisterId { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        [RegularExpression("(^[6-9][0-9]{9}$)", ErrorMessage = "Invalid Mobile Number")]
        public string UserMobileNumber { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
}
