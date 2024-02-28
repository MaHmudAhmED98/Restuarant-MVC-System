using System.ComponentModel.DataAnnotations;

namespace Resturant.Models.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name ="User Name")]
        public string userName {  get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool RememberMe { get; set; } 

    }
}
