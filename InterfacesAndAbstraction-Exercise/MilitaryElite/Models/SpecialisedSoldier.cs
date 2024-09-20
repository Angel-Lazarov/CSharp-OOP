
using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;
using System.Text;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public Corps Corps { get; private set; }

        public override string ToString()
        {
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine(base.ToString());
            //sb.AppendLine($"Corps: {Corps}");

            //return sb.ToString().TrimEnd();
            return base.ToString() + $"{Environment.NewLine}Corps: {Corps}";
        }
    }
}
