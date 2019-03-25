using GarageManager.Models;
using GarageManager.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;

namespace GarageManager.Pages.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Default UserStore constructor uses the default connection string named: DefaultConnection
            var userStore = new UserStore<IdentityUser>();

            // Set ConnectionString to GarageConnectionString
            userStore.Context.Database.Connection.ConnectionString =
                System.Configuration.ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            var manager = new UserManager<IdentityUser>(userStore);

            // Create new user and try to store in DB.
            var user = new IdentityUser { UserName = txtUserName.Text };

            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                try
                {
                    IdentityResult result = manager.Create(user, txtPassword.Text);
                    if (result.Succeeded)
                    {
                        var userDetail = new UserDetailModel
                        {
                            Address = txtAddress.Text,
                            FirstName = txtFirstName.Text,
                            LastName = txtLastName.Text,
                            Guid = user.Id,
                            PostalCode = Convert.ToInt32(txtPostalCode.Text)
                        };

                        var userRepo = new UserDetailRepo();
                        userRepo.InsertUserDetail(userDetail);

                        // Store user in DB
                        var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                        var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                        // If succeedeed, log in the new user and set a cookie and redirect to homepage
                        authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        litStatusMessage.Text = result.Errors.FirstOrDefault();
                    }
                }
                catch (Exception ex)
                {
                    litStatusMessage.Text = ex.ToString();
                }
            }
            else
            {
                litStatusMessage.Text = "Passwords must match!";
            }
        }
    }
}