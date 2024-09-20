
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            //string result = base.ToString() + $" Salary: {Salary}";
            string result = $"{base.ToString()} Salary: {Salary:F2}";
            return result;
        }

    }
}
