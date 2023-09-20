using Domain.Entity;

namespace Domain.Models
{
    public class Contract : EntityBase
    {
        public Contract(Team team, decimal salary, DateTime expiryDate)
        {
            Team = team;
            Salary = salary;
            ExpiryDate = expiryDate;
        }

        public Team Team { get; init; }
        public decimal Salary { get; init; }

        public DateTime ExpiryDate { get; init; }

        public bool IsValid()
        {
            return Salary > 0m && DateTime.Now < ExpiryDate;
        }
    }
}
