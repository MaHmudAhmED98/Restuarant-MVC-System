using Microsoft.EntityFrameworkCore;
using Resturant.Models;
using Resturant.Models.Context;


namespace RestaruantMVC.Models.Reprositray
{
    public class BookReprositray : IBookRepositary
    {
        private readonly ProjectContext context;

        public BookReprositray(ProjectContext context)
        {
            this.context = context;
        }
        public void Delete(int bookId)
        {
            context
                .Books
                .Where(p => p.bookId == bookId)
                .ExecuteUpdate(p => p.SetProperty(p => p.isDeleted, p => true));
        }

        public Book GetById(string id)
        {
           return context.Books.FirstOrDefault(p => p.userId == id);
        }
        public List< Book> GetallBook(string id)
        {
            return context.Books.Where(b=> b.userId == id).ToList();
        }
        public void Insert(Book book)
        {
            context.Books.Add(book);
        }

        
        public bool IsTableEmpty(DateTime arrival, DateTime leave, int tablId)
        {
           
            return context.Books.Where(t => t.Table.tableId == tablId &&
            ((t.arrivedAt >= arrival && t.arrivedAt <= leave )
            ||( t.leaveAt >= arrival&&t.leaveAt <= arrival)
            ||( t.arrivedAt <= arrival &&t.leaveAt >= leave) )).Count() == 0;
        }

        public void Update(Book book)
        {
            context.Books.Update(book);
        }

        public void savechanges()
        {
            context.SaveChanges();
        }

        public List<Table> getalltables()
        {
            return context.Tables.ToList();
        }
        public Table? GetTable(int id)
        {
            return context.Tables.FirstOrDefault(t => t.tableId == id);
        }
        public BookProducts GetBookProductById(int id)
        {
            return context.BookProducts.Include(Book=>Book.bookId).Include(p=>p.id).FirstOrDefault(p => p.id == id);
        }
        public List<Book> GetAll()
        {
            return context.Books.Include(b=> b.BookProduct).ThenInclude(p => p.Products).ToList();
        }
        public Book GetBook(int bookId)
        {
            return context.Books.Include(b=>b.BookProduct).ThenInclude(b=>b.Products).FirstOrDefault(p => p.bookId == bookId);
        }
        public Book GetLastBookByUserId(string UserId)
        {
            return context.Books.Where(p => p.AppUser.Id == UserId).OrderByDescending(b => b.bookId).Include(p=> p.BookProduct).ThenInclude(p=> p.Products).FirstOrDefault();

        }
    }
}
