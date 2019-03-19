using GarageManager.Models;
using GarageManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageManager.Repositories
{
    public class CartRepo : Repository
    {
        public string InsertCart(Cart cart)
        {
            try
            {
                db.Carts.Add(cart);
                db.SaveChanges();

                return "Order was succesfully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string UpdateCart(int id, Cart cart)
        {
            try
            {
                //Fetch object from db
                Cart p = db.Carts.Find(id);

                p.DatePurchased = cart.DatePurchased;
                p.ClientID = cart.ClientID;
                p.Amount = cart.Amount;
                p.IsInCart = cart.IsInCart;
                p.ProductID = cart.ProductID;

                db.SaveChanges();
                return cart.DatePurchased + " was succesfully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string DeleteCart(int id)
        {
            try
            {
                Cart cart = db.Carts.Find(id);

                db.Carts.Attach(cart);
                db.Carts.Remove(cart);
                db.SaveChanges();

                return cart.DatePurchased + "was succesfully deleted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public List<Cart> GetOrdersInCart(string clientId)
        {
            List<Cart> orders = (from x in db.Carts
                                 where x.ClientID == clientId
                                 && x.IsInCart
                                 orderby x.DatePurchased descending
                                 select x).ToList();
            return orders;
        }

        public int GetAmountOfOrders(string clientId)
        {
            try
            {
                int amount = (from x in db.Carts
                              where x.ClientID == clientId
                              && x.IsInCart
                              select x.Amount).Sum();

                return amount;
            }
            catch
            {
                return 0;
            }
        }

        public void UpdateQuantity(int id, int quantity)
        {
            Cart p = db.Carts.Find(id);
            p.Amount = quantity;

            db.SaveChanges();
        }

        public void MarkOrdersAsPaid(List<Cart> carts)
        {
            if (carts != null)
            {
                foreach (Cart cart in carts)
                {
                    Cart oldCart = db.Carts.Find(cart.ID);
                    oldCart.DatePurchased = DateTime.Now;
                    oldCart.IsInCart = false;
                }
                db.SaveChanges();
            }
        }
    }
}