using System.Linq;

namespace Models
{
    public class UserDetailRepo
    {
        public UserDetail GetUserInformation(string guId)
        {
            GarageEntities db = new GarageEntities();
            var info = (from x in db.UserDetails
                        where x.Guid == guId
                        select x).FirstOrDefault();
            return info;
        }

        public void InsertUserDetail(UserDetail userDetail)
        {
            GarageEntities db = new GarageEntities();
            db.UserDetails.Add(userDetail);
            db.SaveChanges();
        }
    }
}