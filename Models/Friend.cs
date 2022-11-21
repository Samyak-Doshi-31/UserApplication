using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApplication.Models
{
    public class Friend
    {
        [Key]
        public int FriendId { get; set; }
        [Required]
        public string FriendFirstName { get; set; }
        [Required]
        public string FriendLastName { get; set; }
        [Required]
        [RegularExpression("(^[6-9][0-9]{9}$)", ErrorMessage = "Invalid Mobile Number")]
        public string FriendMobileNumber { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        public string FriendEmail { get; set; }

        [ForeignKey("FK_Friend_UserRegisterId")]
        public int UserRegisterId { get; set; }
        //public virtual Register GetRegister { get; set; }

    }
}
