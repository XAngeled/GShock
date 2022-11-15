using System.Diagnostics;
using Watch.Modes.Data;

namespace Watch.Modes
{
    public class StopperMode
    {
        Stopper data;
        public StopperMode(Stopwatch stopwatch)
        {
            data = new StopperModeData(stopwatch);
        }
    }
}
