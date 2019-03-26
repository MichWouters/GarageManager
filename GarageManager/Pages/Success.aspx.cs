using GarageManager.Models;
using GarageManager.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;

namespace GarageManager.Pages
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<CartModel> carts = (List<CartModel>)Session[User.Identity.GetUserId()];

            var repo = new CartRepo();
            repo.MarkOrdersAsPaid(carts);

            Session[User.Identity.GetUserId()] = null;
        }
    }
}