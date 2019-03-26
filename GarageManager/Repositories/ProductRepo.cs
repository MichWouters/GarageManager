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
                _db.Products.Add(product);
                _db.SaveChanges();

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
                ProductModel p = _db.Products.Find(id);

                p.Name = product.Name;
                p.Price = product.Price;
                p.TypeID = product.TypeID;
                p.Description = product.Description;
                p.Image = product.Image;

                _db.SaveChanges();
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
                ProductModel product = _db.Products.Find(id);

                _db.Products.Attach(product);
                _db.Products.Remove(product);
                _db.SaveChanges();

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
                ProductModel product = _db.Products.Find(id);
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
                List<ProductModel> products = (from x in _db.Products
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
                    List<ProductModel> products = (from x in _db.Products
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