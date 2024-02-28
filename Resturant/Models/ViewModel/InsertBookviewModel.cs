using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaruantMVC.Models.Reprositray;
using Resturant.Migrations;
using Resturant.Models;
using Table = Microsoft.EntityFrameworkCore.Metadata.Internal.Table;

namespace RestaruantMVC.Models.ViewModel
{
    public class InsertBookviewModel
    {
        public int BookId { get; set; }
        [Required]
        [Display(Name ="Arrived at")]
        public DateTime Arrivedat { get; set; }
        [Required]
        [Display(Name = "Left at")]
        public DateTime Leavedat { get; set; }
        [Display(Name = "User Name")]

        public string? userName { get; set; }
        [Display(Name = "Number of Persons")]

        public int Numberofperson { get; set; }
        [Required(ErrorMessage ="The Table is booked ")]
        [Display(Name = "Table Id")]
        public int tableId { get; set; }
        // public List<Table> tables { get; set; } = new List<Table>();
        [Display(Name = "Table Name")]
        public string? tablename { get; set; }
        [Display(Name = "Total Price")]

        public decimal? price { get; set; }

        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
        public Table? Table { get; set; }
        public static InsertBookviewModel FromDbModel(Book book)
        {
   
            return new InsertBookviewModel
            {   BookId = book.bookId,
                Arrivedat = book.arrivedAt,
                Leavedat = book.leaveAt,
                Numberofperson = book.numOfPersones,
                //tableId = book.TableId,
                tablename = book?.Table?.Name,
                userName = book?.userId,
                price = book?.totalPrice,
                Products = book.BookProduct.Select(p => new ProductViewModel
                {   Image = p.Products.image,
                    ProductName=p.Products.Name,
                    Price = p.Products.price,
                    ProdectType =p.Products.Type
                }).ToList()
            };
        }
    }
}
