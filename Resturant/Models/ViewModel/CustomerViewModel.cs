using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Models.ViewModel
{
    public class CustomerViewModel
    {
        [Required]
        [Display(Name ="First Name")]
        [StringLength(maximumLength:12,MinimumLength =3,ErrorMessage ="Must Be Between 3 and 12 Char ")]
        public string FirstName { get; set; }

        [StringLength(maximumLength: 12, MinimumLength = 3, ErrorMessage = "Must Be Between 3 and 12 Char ")]
        [Display(Name ="Last Name")]
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [MinLength(11 , ErrorMessage = "must be more than 8")]


        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage ="must be more than 8")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Password and Confirm Password not Matching")]
        public string ConfirmedPassword { get; set;}

    }
}
