using System.Collections.Generic;

namespace GarageManager.Models
{
    public class ProductType
    {
        public ProductType()
        {
            this.Products = new HashSet<Product>();
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}