using Newtonsoft.Json;
using RaizenUserRegister.Domain.Interface;
using RaizenUserRegister.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RaizenUserRegister.Application.Services
{
    public class AddressClientService : IAddressClientService
    {
        private readonly HttpClient _httpClient;
        public AddressClientService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<AddressResponse> GetAddressFromZipCode(string zipCode)
        {
            string clientPath = string.Format("https://viacep.com.br/ws/{0}/json/",zipCode);

            var responseString = await _httpClient.GetStringAsync(clientPath);

            var catalog = JsonConvert.DeserializeObject<AddressResponse>(responseString);
            if(catalog is not null) {
                return catalog;
            }

           return await Task.FromResult(new AddressResponse());   
        }
    }
}
