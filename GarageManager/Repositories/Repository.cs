namespace GarageManager.Repositories
{
    public abstract class Repository
    {
        protected ApplicationDbContext _db;

        public Repository()
        {
            _db = new ApplicationDbContext();
        }
    }
}