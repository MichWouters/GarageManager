using GarageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageManager.Repositories
{
    public class CartRepo : Repository
    {
        public string InsertCart(CartModel cart)
        {
            try
            {
                _db.Carts.Add(cart);
                _db.SaveChanges();

                return "Order was succesfully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string UpdateCart(int id, CartModel cart)
        {
            try
            {
                //Fetch object from db
                CartModel oldCart = _db.Carts.Find(id);

                oldCart.DatePurchased = cart.DatePurchased;
                oldCart.ClientID = cart.ClientID;
                oldCart.Amount = cart.Amount;
                oldCart.IsInCart = cart.IsInCart;
                oldCart.ProductID = cart.ProductID;

                _db.SaveChanges();
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
                CartModel cart = _db.Carts.Find(id);

                _db.Carts.Attach(cart);
                _db.Carts.Remove(cart);
                _db.SaveChanges();

                return cart.DatePurchased + "was succesfully deleted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public List<CartModel> GetOrdersInCart(string clientId)
        {
            List<CartModel> orders = (from x in _db.Carts
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
                int amount = (from x in _db.Carts
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
            CartModel p = _db.Carts.Find(id);
            p.Amount = quantity;

            _db.SaveChanges();
        }

        public void MarkOrdersAsPaid(List<CartModel> carts)
        {
            if (carts != null)
            {
                foreach (CartModel cart in carts)
                {
                    CartModel oldCart = _db.Carts.Find(cart.ID);
                    oldCart.DatePurchased = DateTime.Now;
                    oldCart.IsInCart = false;
                }
                _db.SaveChanges();
            }
        }
    }
}