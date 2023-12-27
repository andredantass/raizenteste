using RaizenUserRegister.Application.Abstraction.Interface;
using RaizenUserRegister.Domain.Aggregates;

namespace RaizenUserRegister.Infra.Data.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllWithAddress();
        Task<User> GetByIdWithAddress(string id);
    }
}
