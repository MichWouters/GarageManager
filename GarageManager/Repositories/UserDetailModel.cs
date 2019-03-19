using GarageManager.Models;
using System.Linq;

namespace GarageManager.Repositories
{
    public class UserDetailRepo : Repository
    {
        public UserDetail GetUserInformation(string guId)
        {
            var info = (from x in db.UserDetails
                        where x.Guid == guId
                        select x).FirstOrDefault();
            return info;
        }

        public void InsertUserDetail(UserDetail userDetail)
        {
            db.UserDetails.Add(userDetail);
            db.SaveChanges();
        }
    }
}