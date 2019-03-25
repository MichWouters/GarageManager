using GarageManager.Repositories;
using System;
using System.Net;
using System.Web;
using System.Web.UI;

namespace GarageManager
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Context.User.Identity;
            if (user.IsAuthenticated)
            {
                LnkLogIn.Visible = false;
                lnkRegister.Visible = false;

                litStatus.Visible = true;
                btnLogOut.Visible = true;

                var repo = new CartRepo();
                string userId = "-1";
                //string userId = HttpContext.Current.User.Identity.GetUserId();
                litStatus.Text = string.Format("{0} ({1})", Context.User.Identity.Name, repo.GetAmountOfOrders(userId));
            }
            else
            {
                LnkLogIn.Visible = true;
                lnkRegister.Visible = true;

                litStatus.Visible = false;
                btnLogOut.Visible = false;
            }
        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            //AuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            //authenticationManager.SignOut();
            //Response.Redirect("Pages/Account/Login.aspx");
        }
    }
}