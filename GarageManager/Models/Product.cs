using System.Collections.Generic;

namespace GarageManager.Models
{
    public class Product
    {
        public int ID { get; set; }
        public int TypeID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}