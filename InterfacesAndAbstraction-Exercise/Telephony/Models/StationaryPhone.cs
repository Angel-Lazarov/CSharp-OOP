using Telephony.Models.Interface;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {

        public string Call(string number)
        {
            if (CheckNumber(number))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {number}";
        }

        private bool CheckNumber(string number)
        {
            return number.Any(d => char.IsLetter(d));
        }
    }
}
