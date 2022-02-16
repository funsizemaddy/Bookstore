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
    }
}
