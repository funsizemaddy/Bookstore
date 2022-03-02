using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();
    
        public virtual void AddItem (Book bo, int qty, double cost) 
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == bo.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = bo,
                    Quantity = qty,
                    Price = cost,
                    
                    
                });
            }
            else
            {
                line.Quantity += qty;              
            }
        }
        public virtual void RemoveItem (Book bk)
        {
            Items.RemoveAll(x => x.Book.BookId == bk.BookId);
        }
        public virtual void ClearBasket()
        {
            Items.Clear();
        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Price);
            return sum; 
        }
    }
    
    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
