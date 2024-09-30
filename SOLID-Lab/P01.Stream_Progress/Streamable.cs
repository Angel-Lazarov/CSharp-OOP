namespace P01.Stream_Progress
{
    public abstract class Streamable
    {
        public Streamable(int length, int bytesSent)
        {
            Length = length;
            BytesSent = bytesSent;
        }

        public int Length { get; set; }

        public int BytesSent { get; set; }

    }
}
