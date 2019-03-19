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
                db.ProductTypes.Add(productType);
                db.SaveChanges();

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
                ProductTypeModel p = db.ProductTypes.Find(id);

                p.Name = productType.Name;

                db.SaveChanges();
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
                ProductTypeModel productType = db.ProductTypes.Find(id);

                db.ProductTypes.Attach(productType);
                db.ProductTypes.Remove(productType);
                db.SaveChanges();

                return productType.Name + "was succesfully deleted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }
    }
}