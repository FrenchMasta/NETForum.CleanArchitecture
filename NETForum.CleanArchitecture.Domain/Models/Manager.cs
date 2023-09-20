using Domain.Entity;

namespace Domain.Models
{
    public class Manager : EntityBase
    {
        public Manager(string firstName, string lastName, Contract contract)
        {
            FirstName = firstName;
            LastName = lastName;
            Contract = contract;
        }

        public string FirstName { get; init; }
        public string LastName { get; init; }
        public Contract Contract { get; set; }
    }
}
