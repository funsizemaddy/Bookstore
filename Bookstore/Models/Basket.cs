﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();
    
        public void AddItem (Book bo, int qty, int cost) 
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
                    Price = cost
                    
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Price);
            return sum;
        }
    }
    
    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }

        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}