﻿using eCommerce.Contracts.Repositories;
using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services
{
    public class BasketServices
    {
        IRepositoryBase<Basket> baskets;

        public const string BasketSessionName = "eCommerceBasket";

        public BasketServices(IRepositoryBase<Basket> baskets)
        {
            this.baskets = baskets;
        }

        public Basket createNewBasket(HttpContextBase httpContext)
        {
            //create a new basket.

            //first creare a new cookie.
            HttpCookie cookie = new HttpCookie(BasketSessionName);
            //now create a new basket and set the creation date.
            Basket basket = new Basket();
            basket.date = DateTime.Now;
            basket.Id = Guid.NewGuid();

            //add and persist in the database.
            baskets.Insert(basket);
            baskets.Commit();

            //add the basket id to a cookie
            cookie.Value = basket.Id.ToString();
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);

            return basket;
        }

        public bool AddToBasket(HttpContextBase httpContext, int productId, int quantity)
        {
            bool success = true;

            Basket basket = GetBasket(httpContext);
            BasketItem item = basket.BasketItems.FirstOrDefault(i => i.ProductId == productId);

            if(item == null)
            {
                item = new BasketItem()
                {
                    BasketId = basket.Id,
                    ProductId = productId,
                    Quantity = quantity
                };
                basket.BasketItems.Add(item);
            }
            else
            {
                item.Quantity = item.Quantity + quantity;
            }
            baskets.Commit();

            return success;
        }

        public Basket GetBasket(HttpContextBase httpContext)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(BasketSessionName);
            Basket basket;

            Guid basketId;

            if(cookie != null)
            {
                if(Guid.TryParse(cookie.Value, out basketId))
                {
                    basket = basket.GetById(basketId);
                }
                else
                {
                    basket = createNewBasket(httpContext);
                }
            }
            else
            {
                basket = createNewBasket(httpContext);
            }

            return basket;
        }
    }
}
