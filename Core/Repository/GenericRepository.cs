using Microsoft.EntityFrameworkCore;
using PRWeb.Core.IRepositories;
using PRWeb.Data;

namespace PRWeb.Core.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected ApplicationDbContext context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(ApplicationDbContext _context,
               ILogger _logger)
        {

            _context = _context;
            _logger = _logger;

            dbSet = context.Set<T>();


        }

        public virtual async Task<IEnumerable<T>> All() {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
           await dbSet.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

