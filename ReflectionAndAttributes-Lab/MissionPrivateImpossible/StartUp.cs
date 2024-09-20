namespace Stealer
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            //string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            //string result = spy.AnalyzeAccessModifiers("HighQualityMistakes.Hacker");
            string result = spy.RevealPrivateMethods("Stealer.Hacker");
            //spy.RevealPrivateMethods("Stealer.Hacker");

            Console.WriteLine(result);
        }
    }
}
