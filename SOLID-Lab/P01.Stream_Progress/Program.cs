namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {   
            Music music = new Music("preyer","madona", "vogue", 18, 2 );
            music.BytesSent = 5;

            StreamProgressInfo sp = new StreamProgressInfo( music );
        }
    }
}
