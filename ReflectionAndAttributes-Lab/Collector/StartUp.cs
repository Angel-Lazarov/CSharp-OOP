//namespace Stealer;
namespace Collector;

internal class StartUp
{
    static void Main(string[] args)
    {
        Spy spy = new Spy();

        //string result = spy.AnalyzeAccessModifiers("HighQualityMistakes.Hacker");
        string result = spy.CollectGettersAndSetters("Collector.Hacker");

        Console.WriteLine(result);
    }
}
