using System.ComponentModel.DataAnnotations;

namespace Resturant.Models
{
    public enum productType
    {
        meal =1 ,
        drink =2
    }
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[]? image { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal price { get; set; }
        public int count { get; set; }

        
        public productType? Type { get; set; }

        public List<BookProducts> BookProduct { get; set; } = new List<BookProducts>();

    }
}
