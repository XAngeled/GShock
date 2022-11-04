using System.Timers;
using Watch.Modes.Actions;

namespace Watch.Modes
{
    /// <summary>
    /// A mode that represents a normal clock.
    /// </summary>
    public class TimeMode : IMode
    {
        public event Action? dataChanged;

        private double _updateInterval;
        private System.Timers.Timer _outputUpdater;
        private TimeOffset _timeOffset;
        private List<IModeAction<TimeOffset>> _actions;

        public TimeMode(TimeOffset timeOffset, List<IModeAction<TimeOffset>> actions, double updateInterval)
        {
            _timeOffset = timeOffset;
            _actions = actions;
            _updateInterval = updateInterval;
            _outputUpdater = new System.Timers.Timer(_updateInterval);
            _outputUpdater.Elapsed += UpdateOutput;
            _outputUpdater.AutoReset = true;
            _outputUpdater.Start();
        }

        public void ActivateAction(string actionName)
        {
            // Check that such an action exists
            if (!_actions.Exists(action => { return action.Name == actionName; }))
            {
                throw new ArgumentException($"Action {actionName} does not exist");
            }

            IModeAction<TimeOffset> action = (from _action in _actions
                                              where _action.Name == actionName
                                              select _action).First();
            action.Execute(_timeOffset);
        }
        public void ActivateAction(int action)
        {
            _actions[action].Execute(_timeOffset);
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

        private void UpdateOutput(object? sender, ElapsedEventArgs e)
        {
            dataChanged?.Invoke();
        }

        public override string ToString()
        {
            
            return (TimeOnly.FromDateTime(DateTime.Now + _timeOffset.Offset)).ToString("HH:mm:ss.fff");
        }
    }
}
