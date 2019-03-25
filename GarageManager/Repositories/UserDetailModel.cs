using GarageManager.Models;
using System.Linq;

namespace GarageManager.Repositories
{
    public class UserDetailRepo : Repository
    {
        public UserDetailModel GetUserInformation(string guId)
        {
            var info = (from x in _db.UserDetails
                        where x.Guid == guId
                        select x).FirstOrDefault();
            return info;
        }

        public void InsertUserDetail(UserDetailModel userDetail)
        {
            _db.UserDetails.Add(userDetail);
            _db.SaveChanges();
        }
    }
}