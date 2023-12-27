using RaizenUserRegister.Application.Abstraction.Domain;

namespace RaizenUserRegister.Domain.Aggregates
{
    public class Address : Entity
    {
        public string userId { get; set; }
        public string street { get; set; }
        public string zipCode { get; set; }
        public string complement { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int number { get; set; }
        public string neighborhood { get; set; }
        public User user { get; set; }

    }
}
