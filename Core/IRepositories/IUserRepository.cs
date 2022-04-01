using PRWeb.Models;

namespace PRWeb.Core.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
       // Task<string> GetFirstNameAndLastName(Guid id);
    }
}
