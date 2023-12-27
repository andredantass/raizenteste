namespace RaizenUserRegister.Domain.Request
{
    public class UserRequest
    {
        public string id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string secondName { get; set; }
        public string document { get; set; }
        public string nickname { get; set; }
        public string password { get; set; }
        public string zipCode { get; set; }
    }
}
