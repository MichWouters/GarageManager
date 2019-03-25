using GarageManager.Models;
using GarageManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GarageManager.Pages.Management
{
    public partial class ManageProductTypes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ProductTypeRepo repo = new ProductTypeRepo();
            ProductTypeModel productTypeModel = CreateProductType();

            lblResult.Text = repo.InsertProductType(productTypeModel);
        }

        private ProductTypeModel CreateProductType()
        {
            var productTypeModel = new ProductTypeModel();
            productTypeModel.Name = txtName.Text;

            return productTypeModel;
        }
    }
}