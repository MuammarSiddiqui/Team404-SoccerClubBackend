using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BaseRepository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MyContext Db;
        protected readonly DbSet<T> DbSet;
        protected Repository(MyContext db)
        {
            Db = db;
            DbSet = db.Set<T>();
        }
        public async Task<T> Add(T entity)
        {
            try
            {
                DbSet.Add(entity);
                await SaveChanges();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> SaveChanges()
        {
            try
            {
                return await Db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Dispose()
        {
            Db?.Dispose();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await DbSet.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> GetById(Guid Id)
        {
            try
            {
                Db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
#pragma warning disable CS8603 // Possible null reference return.
                return await DbSet.FindAsync(Id);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                DbSet.Update(entity);
                await SaveChanges();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
