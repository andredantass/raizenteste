using RaizenUserRegister.Domain.Request;
using RaizenUserRegister.Domain.Response;

namespace RaizenUserRegister.Domain.Interface
{
    public interface IUserRegisterService
    {
        Task<bool> AddUser(UserRequest request);
        Task<bool> RemoveUser(string id);
        Task<bool> UpdateUser(UserRequest request);
        Task<UserResponse> GetUser(string id);
        Task<List<UserResponse>> GetAll();
    }
}