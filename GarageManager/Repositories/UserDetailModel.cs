using GarageManager.Models;
using System.Linq;

namespace GarageManager.Repositories
{
    public class UserDetailRepo : Repository
    {
        public UserDetailModel GetUserInformation(string guId)
        {
            var info = (from x in db.UserDetails
                        where x.Guid == guId
                        select x).FirstOrDefault();
            return info;
        }

        public void InsertUserDetail(UserDetailModel userDetail)
        {
            db.UserDetails.Add(userDetail);
            db.SaveChanges();
        }
    }
}