namespace Watch
{
    /// <summary>
    /// Represents an offset of time. Made in order to send TimeSpan as ref.
    /// </summary>
    public class TimeOffset
    {
        public TimeSpan Offset { get; set; }

        public TimeOffset()
        {
            Offset = TimeSpan.Zero;
        }
        public TimeOffset(TimeSpan offset)
        {
            Offset = offset;
        }
        public TimeOffset(DateTime dateTime)
        {
            Offset = dateTime - DateTime.Now;
        }
    }
}
