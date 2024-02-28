using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Models
{
    public class BookProducts
    {

        public int id { get; set; }
        [ForeignKey("Book")]
        public int bookId { get; set; }
        [ForeignKey("Products")]

        public int prodId { get; set; }

        public int Count { get; set; }

        public Book? Book { get; set; }

        public Products? Products { get; set; }





    }
}
