namespace GarageManager.Repositories
{
    public abstract class Repository
    {
        protected ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}