using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class EfCheckoutRepository : ICheckoutRepository
    {
        private BookstoreContext context;

        public EfCheckoutRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Checkout> checkouts => context.checkouts.Include(x => x.Lines).ThenInclude(x => x.Book); 

        public void SaveCheckout(Checkout checkout)
        {
            context.AttachRange(checkout.Lines.Select(x => x.Book));
            
            if (checkout.CheckoutId == 0)
            {
                context.checkouts.Add(checkout);
            }
            context.SaveChanges();
        }
    }
}
