
using System.ComponentModel.DataAnnotations;



namespace ASPNETCoreIdentityDemo_Application.Dto
{
    public class RegisterRequestDto
    {
        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
       // [Remote(action: "IsEmailAvailable", controller: "Account")]
        public string Email { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "UserName")]
        public string? UserName { get; set; }
    }
}
