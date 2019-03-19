using System;

/// <summary>
/// Summary description for ProductTypeTypeModel
/// </summary>
public class ProductTypeRepo
{
    public string InsertProductType(ProductType productType)
    {
        try
        {
            GarageEntities db = new GarageEntities();
            db.ProductTypes.Add(productType);
            db.SaveChanges();

            return productType.Name + "was succesfully inserted";
        }
        catch (Exception e)
        {
            return "Error:" + e;
        }
    }

    public string UpdateProductType(int id, ProductType productType)
    {
        try
        {
            GarageEntities db = new GarageEntities();

            //Fetch object from db
            ProductType p = db.ProductTypes.Find(id);

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
            GarageEntities db = new GarageEntities();
            ProductType productType = db.ProductTypes.Find(id);

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