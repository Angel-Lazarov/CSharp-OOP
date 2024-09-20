using Telephony.Models.Interface;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string number)
        {
            if (CheckNumber(number)) 
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {number}";
        }


        public string Brows(string url)
        {
            if (CheckUrl(url)) 
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }

        private bool CheckUrl(string url)
        {
            return url.Any(l => char.IsDigit(l));
        }

        private bool CheckNumber(string number)
        {
            return number.Any(d => char.IsLetter(d));
        }
    }
}
