using PRWeb.Core.IConfiguration;
using PRWeb.Core.IRepositories;
using PRWeb.Core.Repository;

namespace PRWeb.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger _logger;


        public IUserRepository Users { get; private set; }
        IUserRepository IUnitOfWork.Users { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory) { 

            _context = context;
            _logger = loggerFactory.CreateLogger("logs");


            Users = new UserRepository(_context, _logger);
       
        
        }

        public async Task CompleteAsync() { 
        
        await _context.SaveChangesAsync();
        }


        public void Dispose() { _context.Dispose(); }

        public Task ComleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
