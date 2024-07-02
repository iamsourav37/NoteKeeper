using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NoteKeeper.Web.Models.DTO.AccountDTOs
{
    public class UserProfileCreateDTO
    {

        [Required(ErrorMessage = "Please enter your email to register !")]
        [EmailAddress(ErrorMessage = "Email should be in proper format !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide the password !")]
        [DataType(DataType.Password)]
        [MinLength(7, ErrorMessage ="Password must be atleast 7 character long !")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm the password.")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage ="Please enter the same password !")]
        public string ConfirmPassword { get; set; }
    }
}
