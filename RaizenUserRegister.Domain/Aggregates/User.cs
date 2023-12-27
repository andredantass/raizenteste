using RaizenUserRegister.Application.Abstraction.Domain;

namespace RaizenUserRegister.Domain.Aggregates
{
    public class User : Entity
    {
        public string email { get; set; }
        public string name { get; set; }
        public string secondName { get; set; }
        public string document { get; set; }
        public string nickname { get; set; }
        public string password { get; set; }
        public Address address { get; set; }

    }
}
