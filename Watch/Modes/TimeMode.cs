using System.Timers;
using Utilities;
using Watch.Modes.Actions;

namespace Watch.Modes
{
    public class TimeMode : IMode
    {
        public string Name { get; set; }
        public event Action? dataChanged;

        private readonly double _updateInterval;
        private readonly System.Timers.Timer _outputUpdater;
        private readonly TimeOffset _timeOffset;
        private Clock _clock;
        private List<IModeAction<Clock>> _actions;

        public TimeMode(TimeOffset timeOffset, List<IModeAction<Clock>> actions, double updateInterval, Clock clock)
        {
            Name = "Time";
            _timeOffset = timeOffset;
            _actions = actions;
            _updateInterval = updateInterval;
            _clock = clock;
            _outputUpdater = new System.Timers.Timer(_updateInterval);
            InitializeTimer();
        }

        public void ActivateAction(string actionName)
        {
            IEnumerable<IModeAction<Clock>> actions = from _action in _actions
                                                           where _action.Name == actionName
                                                           select _action;
            if (!actions.Any())
                throw new ArgumentException($"Action {actionName} does not exist");


            IModeAction<Clock> action = actions.First();
            action.Execute(_clock);
        }
        public void ActivateAction(int action)
        {
            _actions[action].Execute(_clock);
            dataChanged?.Invoke();
        }

        public List<string> GetActions()
        {
            List<string> actionNames = new List<string>();
            foreach (var action in _actions)
            {
                actionNames.Add(action.Name);
            }
            return actionNames;
        }
        public void AddAction(IModeAction<Clock> action)
        {
            _actions.Add(action);
        }
        public override string ToString()
        {

            return (TimeOnly.FromDateTime(DateTime.Now + _timeOffset.Offset)).ToString("HH:mm:ss.fff");
        }

        private void UpdateOutput(object? sender, ElapsedEventArgs e)
        {
            dataChanged?.Invoke();
        }
        private void InitializeTimer()
        { 
            _outputUpdater.Elapsed += UpdateOutput;
            _outputUpdater.Start();
        }
    }
}
