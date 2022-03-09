using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class EfBookstoreRespository : IBookstoreRepository
    {
        private BookstoreContext context { get; set; }

        public EfBookstoreRespository (BookstoreContext rep)
        {
            context = rep;
        }

        public IQueryable<Book> Books => context.Books;

        public void SaveBooks(Book b)
        {
            context.SaveChanges();
        }

        public void CreateBook(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteBook(Book b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
    }
}
