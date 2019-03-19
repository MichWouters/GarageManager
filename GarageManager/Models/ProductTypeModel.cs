using System.Collections.Generic;

namespace GarageManager.Models
{
    public class ProductTypeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }
    }
}