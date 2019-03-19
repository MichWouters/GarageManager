namespace GarageManager.Repositories
{
    public abstract class Repository
    {
        protected ApplicationDbContext db;

        public Repository()
        {
            db = new ApplicationDbContext();
        }
    }
}