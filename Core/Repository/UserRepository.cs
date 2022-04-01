using Microsoft.EntityFrameworkCore;
using PRWeb.Core.IRepositories;
using PRWeb.Data;
using PRWeb.Models;

namespace PRWeb.Core.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {


        }

        public override async Task<IEnumerable<User>> All()
        {

            try
            {
                return await dbSet.ToListAsync();

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(UserRepository));
                return new List<User>();
               


            }

        }

        public override async Task<bool> Upsert(User entity) {


            try
            {
                    var existUser = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();


                if (existUser == null)
                    return await Add(entity);

                        existUser.Name = entity.Name;
                        existUser.lastaName = entity.lastaName;
                        existUser.Email = entity.Email;

                        return true;

                    
            }

            catch (Exception ex)
            {
                    _logger.LogError(ex, "{Repo} Upsert method error", typeof(UserRepository));
                    return false;

            }
        }


        public override async Task<bool> Delete(Guid id) {


            try
            {
                var exist = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (exist !=null ) {

                    dbSet.Remove(exist);
                    return true;



                }

                return false;

            }
            catch(Exception ex) { 

                _logger.LogError(ex, "{Repo} Delete method error", typeof(UserRepository));
                return false;
            }
        
        }
    }
}
