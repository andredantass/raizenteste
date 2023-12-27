using Microsoft.EntityFrameworkCore;
using RaizenUserRegister.Application.Abstraction.Repository;
using RaizenUserRegister.Domain.Aggregates;
using RaizenUserRegister.Infra.Data.DBContext;

namespace RaizenUserRegister.Infra.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RaizenDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetAllWithAddress()
            => await DBSet.Include(x => x.address).ToListAsync();

        public async Task<User?> GetByIdWithAddress(string id)
           => await DBSet.Where(y => y.Id == id).Include(x => x.address).FirstOrDefaultAsync();
    }
}
