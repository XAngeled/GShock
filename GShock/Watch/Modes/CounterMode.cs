using System;
using Watch.Modes.Actions;

namespace Watch.Modes
{
    /// <summary>
    /// A clock that... counts.
    /// </summary>
    public class CounterMode : IMode
    {
        public event Action dataChanged;
        private List<IModeAction<Counter>> _actions;
        private Counter _counter;

        public CounterMode(List<IModeAction<Counter>> actions, Counter counter)
        {
            _actions = actions;
            _counter = counter;
        }

        public void ActivateAction(string actionName)
        {
            // Check that such an action exists
            if (!_actions.Exists(action => { return action.Name == actionName; }))
            {
                throw new ArgumentException($"Action {actionName} does not exist");
            }

            IModeAction<Counter> action = (from _action in _actions
                                              where _action.Name == actionName
                                              select _action).First();
            action.Execute(_counter);
        }

        public void ActivateAction(int action)
        {
            _actions[action].Execute(_counter);
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

        public override string ToString()
        {
            return _counter.ToString();
        }
    }
}
