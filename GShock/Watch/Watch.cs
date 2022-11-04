using Watch.Modes;

namespace Watch
{
    /// <summary>
    /// Represents a watch that contains different modes. Each mode is assigned data and actions that affect the data.
    /// </summary>
    public class Watch
    {
        /// <summary>
        /// Invoked when the output of the watch is changed.
        /// </summary>
        public event Action? dataChanged;
        /// <summary>
        /// The queue of modes the watch cycles through. The mode in the front is the one selected.
        /// </summary>
        public Queue<IMode> Modes { get; set; }
        /// <summary>
        /// The currently selected mode.
        /// </summary>
        public IMode CurrentMode { get; private set; }

        /// <summary>
        /// Creates a new watch.
        /// </summary>
        /// <param name="modes">A collection of modes to cycle through. If empty an exception is thrown.</param>
        /// <exception cref="ArgumentException">Argument 'modes' must contain at least one item.</exception>
        public Watch(ICollection<IMode> modes)
        {
            if (!modes.Any())
                throw new ArgumentException("Argument 'modes' must contain at least one item.");
            Modes = new Queue<IMode>(modes);
            CurrentMode = Modes.Dequeue();
            CurrentMode.dataChanged += UpdateOutput;
        }

        /// <summary>
        /// Cycles and selects the next mode in the watch.
        /// </summary>
        public void CycleMode()
        {
            CurrentMode.dataChanged -= UpdateOutput;
            Modes.Enqueue(CurrentMode);
            CurrentMode = Modes.Dequeue();
            CurrentMode.dataChanged += UpdateOutput;
            dataChanged?.Invoke();
        }

        /// <summary>
        /// Activates an action by its name.
        /// </summary>
        /// <param name="action">The name of the action in the selected mode to perform.</param>
        public void ActivateAction(string action)
        {
            CurrentMode.ActivateAction(action);
        }
        /// <summary>
        /// Activates an action by its index.
        /// </summary>
        /// <param name="action">The index of the action in the selected mode.</param>
        public void ActivateAction(int action)
        {
            CurrentMode.ActivateAction(action);
        }
        /// <summary>
        /// Get a list of action names, ordered by the same order of the action's indexes in the selected mode.
        /// </summary>
        /// <returns>A list of actions ordered by the same order of their indexes in the selected mode.</returns>
        public List<string> GetActions()
        {
            return CurrentMode.GetActions();
        }
        public override string ToString()
        {
            if (CurrentMode != null)
#pragma warning disable CS8603 // Possible null reference return.
                // Cannot be null since we assign it in constructor, and it is checked right before the call.
                return CurrentMode.ToString();
#pragma warning restore CS8603 // Possible null reference return.
            return "Empty watch";
        }

        private void UpdateOutput()
        {
            dataChanged?.Invoke();
        }
    }
}
