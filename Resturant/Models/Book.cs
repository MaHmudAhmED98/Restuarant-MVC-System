using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Models
{
    public class Book
    {
        public int bookId { get; set; }

        [ForeignKey("Table")]
        public int TableId { get; set; }
        public Table? Table { get; set; }
        public DateTime arrivedAt { get; set; }
        public DateTime leaveAt { get; set; }
        public string userId { get; set; }
        public int numOfPersones { get; set; }
        public List<BookProducts> BookProduct { get; set; } = new List<BookProducts>();
        

        [DataType(DataType.Currency)]
        public decimal totalPrice { get; set; }
        public bool isDeleted { get; set; }=false;

        public AppUser AppUser { get; set; }

        public void AddNewproduct(Products products ,int count)
        {
            BookProducts bookProducts = new BookProducts()
            {
                prodId = products.Id,
                Count = count,
                bookId = this.bookId,
                Book=this,
                Products=products,

            };
            this.BookProduct.Add(bookProducts);
        }

    }
}
