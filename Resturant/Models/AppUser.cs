using Microsoft.AspNetCore.Identity;

namespace Resturant.Models
{
    public class AppUser:IdentityUser
    {
        
        public List<Book> Books { get; set; }=new List<Book>();

    }
}
