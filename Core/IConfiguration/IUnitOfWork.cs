using PRWeb.Core.IRepositories;

namespace PRWeb.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; set; }

        Task ComleteAsync();
    }
}
