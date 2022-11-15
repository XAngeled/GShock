using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch.Modes.Data
{
    public class Stopper
    {
        private Stopwatch _stopper;
        public List<TimeSpan> Results { get; }

        public Stopper(Stopwatch stopwatch, List<TimeSpan> results)
        {
            _stopper = stopwatch;
            Results = results;
        }
        public void Start()
        {
            _stopper.Start();
        }
        public void Stop()
        {
            _stopper.Stop();
        }
        public void AddResult()
        {
            Results.Add(_stopper.Elapsed);
        }
        public void ClearResults()
        {
            Results.Clear();
        }
        public void Reset()
        {
            _stopper.Reset();
        }
    }
}
