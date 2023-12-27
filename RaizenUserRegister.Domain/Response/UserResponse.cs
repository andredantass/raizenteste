namespace RaizenUserRegister.Domain.Response
{
    public class UserResponse
    {
        public string id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string secondName { get; set; }
        public string document { get; set; }
        public string nickname { get; set; }
        public string password { get; set; }

        public AddressResponse address { get; set; }
    }
    
}
