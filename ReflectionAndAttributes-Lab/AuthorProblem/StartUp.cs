namespace AuthorProblem;

[Author("Victor")]
public class StartUp
{
    [Author("George")]
    [Author("rr")]
    public static void Main(string[] args)
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }

    [Author("n")]
    public void CustomM() { }
}

