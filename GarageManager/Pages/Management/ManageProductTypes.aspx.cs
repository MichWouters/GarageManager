using GarageManager.Models;
using GarageManager.Repositories;
using System;
using System.Web.UI;

public partial class Pages_Management_ManageProductTypes : Page
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