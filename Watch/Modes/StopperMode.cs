using System.Diagnostics;

namespace Watch.Modes
{
    public class StopperMode
    {
        private Stopwatch _stopwatch;
        private List<TimeSpan> _Results;
        public StopperMode(Stopwatch stopwatch)
        {
            _stopwatch = stopwatch;
            _Results = new List<TimeSpan>();
        }
    }
}
