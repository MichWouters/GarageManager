using GarageManager.Models;
using System;

namespace GarageManager.Repositories
{
    public class ProductTypeRepo : Repository
    {
        public string InsertProductType(ProductTypeModel productType)
        {
            try
            {
                _db.ProductTypes.Add(productType);
                _db.SaveChanges();

                return productType.Name + "was succesfully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string UpdateProductType(int id, ProductTypeModel productType)
        {
            try
            {
                //Fetch object from db
                ProductTypeModel p = _db.ProductTypes.Find(id);

                p.Name = productType.Name;

                _db.SaveChanges();
                return productType.Name + "was succesfully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string DeleteProductType(int id)
        {
            try
            {
                ProductTypeModel productType = _db.ProductTypes.Find(id);

                _db.ProductTypes.Attach(productType);
                _db.ProductTypes.Remove(productType);
                _db.SaveChanges();

                return productType.Name + "was succesfully deleted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }
    }
}