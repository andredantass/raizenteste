using RaizenUserRegister.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaizenUserRegister.Domain.Interface
{
    public interface IAddressClientService
    {
        Task<AddressResponse> GetAddressFromZipCode(string zipCode);
    }
}
