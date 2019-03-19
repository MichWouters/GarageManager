using System;

namespace GarageManager.Models
{
    public class CartModel
    {
        public int ID { get; set; }
        public string ClientID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public DateTime DatePurchased { get; set; }
        public bool IsInCart { get; set; }

        public virtual ProductModel Product { get; set; }
    }
}