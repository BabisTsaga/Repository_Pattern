namespace PRWeb.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class 
    {
        Task<IEnumerable<T>> All();

        Task<T> GetById(Guid id);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task Delete(Guid id);
        Task<bool> Upsert(T entity);

    }
    


    }

