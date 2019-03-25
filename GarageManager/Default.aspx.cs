using GarageManager.Models;
using GarageManager.Repositories;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GarageManager
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var repo = new ProductRepo();
            List<ProductModel> products = repo.GetAllProducts();

            if (products != null)
            {
                foreach (ProductModel product in products)
                {
                    Panel productPanel = new Panel();
                    ImageButton imageButton = new ImageButton
                    {
                        ImageUrl = "~/Images/Products/" + product.Image,
                        CssClass = "productImage",
                        PostBackUrl = string.Format("~/Pages/Product.aspx?id={0}", product.ID)
                    };
                    Label lblName = new Label
                    {
                        Text = product.Name,
                        CssClass = "productName"
                    };
                    Label lblPrice = new Label
                    {
                        Text = "£ " + product.Price,
                        CssClass = "productPrice"
                    };

                    productPanel.CssClass = "col-md-3";
                    productPanel.Controls.Add(imageButton);
                    productPanel.Controls.Add(new Literal { Text = "<br/>" });
                    productPanel.Controls.Add(lblName);
                    productPanel.Controls.Add(new Literal { Text = "<br/>" });
                    productPanel.Controls.Add(lblPrice);

                    //Add dynamic controls to static control
                    pnlProducts.Controls.Add(productPanel);
                }
            }
            else
                pnlProducts.Controls.Add(new Literal { Text = "No products found!" });
        }
    }
}