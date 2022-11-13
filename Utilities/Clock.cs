namespace Utilities
{
    public class Clock
    {
        private TimeOffset _offset;
        public Clock(TimeOffset offset)
        {
            _offset = offset;
        }

        public void ModifyTime(TimeSpan timeDifference)
        {
            _offset += timeDifference;
        }
        public void SetTime(DateTime newDateTime)
        {
            _offset.Offset = newDateTime - DateTime.Now;
        }
        public void ResetTime()
        {
            _offset.ResetOffset();
        }
    }
}