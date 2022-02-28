using Bookstore.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class SessionBasket : Basket
    {
        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            // ? means it may be null, ?? means otherwise
            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            basket.Session = session; 

            return basket; 
        }

        [JsonIgnore]
        public ISession Session { get; set; }



        public override void AddItem(Book bo, int qty, double cost)
        {
            base.AddItem(bo, qty, cost);
            Session.SetJson("Basket", this);
        }
        public override void RemoveItem(Book bk)
        {
            base.RemoveItem(bk);
            Session.SetJson("Basket", this);
        }
        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }
}
