using RaizenUserRegister.Domain.Aggregates;
using RaizenUserRegister.Domain.Interface;
using RaizenUserRegister.Domain.Request;
using RaizenUserRegister.Domain.Response;
using RaizenUserRegister.Infra.Data.Repository;
using System.Net;

namespace RaizenUserRegister.Application.Services
{
    public class UserRegisterService : IUserRegisterService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAddressClientService _addressClientService;
        public UserRegisterService(IUserRepository userRepository, IAddressClientService addressClientService)
        {
            _userRepository = userRepository;
            _addressClientService = addressClientService;

        }
        public async Task<bool> AddUser(UserRequest request)
        {
            var completeAddress = _addressClientService.GetAddressFromZipCode(request.zipCode).Result;

            var newUser = new User()
            {
                name = request.name,
                email = request.email,
                secondName = request.secondName,
                document = request.document,
                nickname = request.nickname,
                password = request.password,
                address = completeAddress != null ? new Address()
                {
                    street = completeAddress.logradouro ?? "Sem Endereço",
                    zipCode = request.zipCode,
                    neighborhood = completeAddress.bairro,
                    state = completeAddress.uf,
                    city = completeAddress.localidade
                } : new Address()
            };

            try
            {
                await _userRepository.AddAsync(newUser);
                await _userRepository.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                return false;
            }
            
        }

        public async Task<List<UserResponse>> GetAll()
        {
            var users = await _userRepository.GetAllWithAddress();

            if (users is not null)
            {
                return users.Select(x => new UserResponse()
                {
                    id = x.Id,
                    document = x.document,
                    email = x.email,
                    name = x.name,
                    secondName = x.secondName,
                    nickname = x.nickname,
                    password = x.password,
                    address = new AddressResponse()
                    {
                        cep = x.address.zipCode,
                        bairro = x.address.neighborhood,
                        logradouro = x.address.street,
                        localidade = x.address.city,
                        uf = x.address.state
                    }
                }).ToList();
            }
            return await Task.FromResult(new List<UserResponse>());
        }

        public async Task<UserResponse> GetUser(string id)
        {
            var user =  await _userRepository.GetByIdAsync(id);

            if(user is not null)
            {
                return new UserResponse()
                {
                    name = user.name,
                    email = user.email,
                    secondName = user.secondName,
                    document = user.document,
                };
            }

           return await Task.FromResult(new UserResponse());
        }

        public async Task<bool> RemoveUser(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user is not null)
            {
                _userRepository.Delete(user);
                await _userRepository.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<bool> UpdateUser(UserRequest request)
        {
            var user = await _userRepository.GetByIdWithAddress(request.id);
            AddressResponse completeAddress = null;

            if (user is not null && (request.zipCode != user?.address.zipCode))
            {
                completeAddress = _addressClientService.GetAddressFromZipCode(request.zipCode).Result;
                var newAddress = new Address()
                {
                    street = completeAddress.logradouro ?? "Sem Endereço",
                    zipCode = request.zipCode,
                    neighborhood = completeAddress.bairro,
                    state = completeAddress.uf,
                    city = completeAddress.localidade
                };

                user.address = newAddress;
            }
            if (user is not null)
            {
                user.name = request.name;
                user.email = request.email;
                user.secondName = request.secondName;
                user.document = request.document;

                _userRepository.Update(user);

                await _userRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }
           
    }
}
