using Telephony.Core.Interfaces;
using Telephony.Models.Interface;
using Telephony.Models;
using Telephony.IO.Interfaces;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;

        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            string[] numbers = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string number in numbers)
            {
                try
                {
                    ICallable phone = null;

                    if (number.Length == 7)
                    {
                        phone = new StationaryPhone();
                    }
                    else
                    {
                        phone = new Smartphone();
                    }

                    writer.WriteLine(phone.Call(number));

                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            foreach (string url in urls)
            {
                try
                {
                    IBrowsable smart = new Smartphone();
                    writer.WriteLine(smart.Brows(url));
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

        }
    }
}
