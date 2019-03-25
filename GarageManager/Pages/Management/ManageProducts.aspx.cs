using GarageManager.Models;
using GarageManager.Repositories;
using System;
using System.Collections.Generic;
using System.IO;

namespace GarageManager.Pages.Management
{
    public partial class ManageProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetImages();

                //Check if product is being updated
                if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    FillForm(id);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var productRepo = new ProductRepo();
            var product = CreateProduct();

            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                lblResult.Text = productRepo.UpdateProduct(id, product);
            }
            else
            {
                lblResult.Text = productRepo.InsertProduct(product);
            }
        }

        private void FillForm(int id)
        {
            try
            {
                var productRepo = new ProductRepo();
                var product = productRepo.GetProduct(id);

                txtDescription.Text = product.Description;
                txtName.Text = product.Name;
                txtPrice.Text = product.Price.ToString();

                ddlImage.SelectedValue = product.Image;
                ddlType.SelectedValue = product.TypeID.ToString();
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.ToString();
            }
        }

        private void GetImages()
        {
            try
            {
                // Get all filepaths
                string[] images = Directory.GetFiles(Server.MapPath("~/Images/Products/"));

                // Get all filenames and add them to an arraylist
                var imageList = new List<string>();
                foreach (string image in images)
                {
                    string imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                    imageList.Add(imageName);
                }

                // Set the arrayList as the dropdownview's datasource and refresh
                ddlImage.DataSource = imageList;
                ddlImage.AppendDataBoundItems = true;
                ddlImage.DataBind();
            }
            catch (Exception e)
            {
                lblResult.Text = e.ToString();
            }
        }

        private ProductModel CreateProduct()
        {
            var product = new ProductModel
            {
                Name = txtName.Text,
                Price = Convert.ToDouble(txtPrice.Text),
                TypeID = Convert.ToInt32(ddlType.SelectedValue),
                Description = txtDescription.Text,
                Image = ddlImage.SelectedValue
            };

            return product;
        }
    }
}