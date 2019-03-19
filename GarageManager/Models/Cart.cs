using System;

namespace GarageManager.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public string ClientID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public Nullable<System.DateTime> DatePurchased { get; set; }
        public bool IsInCart { get; set; }

        public virtual Product Product { get; set; }
    }
}