using GarageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageManager.Repositories
{
    public class ProductRepo : Repository
    {
        public string InsertProduct(ProductModel product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();

                return product.Name + " was succesfully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string UpdateProduct(int id, ProductModel product)
        {
            try
            {
                //Fetch object from db
                ProductModel p = db.Products.Find(id);

                p.Name = product.Name;
                p.Price = product.Price;
                p.TypeID = product.TypeID;
                p.Description = product.Description;
                p.Image = product.Image;

                db.SaveChanges();
                return product.Name + " was succesfully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string DeleteProduct(int id)
        {
            try
            {
                ProductModel product = db.Products.Find(id);

                db.Products.Attach(product);
                db.Products.Remove(product);
                db.SaveChanges();

                return product.Name + " was succesfully deleted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public ProductModel GetProduct(int id)
        {
            try
            {
                ProductModel product = db.Products.Find(id);
                return product;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ProductModel> GetAllProducts()
        {
            try
            {
                List<ProductModel> products = (from x in db.Products
                                          select x).ToList();
                return products;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ProductModel> GetProductsByType(int typeId)
        {
            try
            {
                {
                    List<ProductModel> products = (from x in db.Products
                                              where x.TypeID == typeId
                                              select x).ToList();
                    return products;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}