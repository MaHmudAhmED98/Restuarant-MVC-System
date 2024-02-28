using Resturant.Models;

namespace RestaruantMVC.Models.Reprositray
{
    public interface IBookRepositary
    {
        public Book GetById(string id);
        public List<Book> GetAll();
        public Book GetBook(int bookId);
        public void Insert(Book book);
        public void Update(Book book);
        public void Delete(int bookId);
        public List<Book> GetallBook(string id);
        public void savechanges();
        public List<Table> getalltables();
        public Table? GetTable(int bookId);
        public bool IsTableEmpty(DateTime arrival, DateTime leave, int tablid);
        public Book GetLastBookByUserId(string UserId);
        public BookProducts GetBookProductById(int id);
    }
}
