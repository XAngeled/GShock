using Watch.Modes;

namespace Watch
{
    public class Watch
    {
        public event Action? dataChanged;
        public Queue<IMode> Modes { get; set; }
        public IMode? CurrentMode { get 
            { 
                Modes.TryPeek(out IMode? mode);
                return mode;
            } 
        } 

        public Watch(ICollection<IMode> modes)
        {
            Modes = new Queue<IMode>(modes);
            if (CurrentMode != null)
            {
                CurrentMode.dataChanged += UpdateOutput;
            }
        }

        public void AddMode(IMode mode)
        {
            Modes.Enqueue(mode);
        }

        public void CycleMode()
        {
            if (CurrentMode != null)
            {
                CurrentMode.dataChanged -= UpdateOutput;
                Modes.Enqueue(Modes.Dequeue());
                CurrentMode.dataChanged += UpdateOutput;
                dataChanged?.Invoke();
            }
        }

        public void ActivateAction(string action)
        {
            if (CurrentMode != null)
                CurrentMode.ActivateAction(action);
        }

        public void ActivateAction(int action)
        {
            if (CurrentMode != null)
                CurrentMode.ActivateAction(action);
        }

        public List<string> GetActions()
        {
            if (CurrentMode != null)
                return CurrentMode.GetActions();
            return new List<string>();
        }
        public override string ToString()
        {
            return CurrentMode != null ? CurrentMode.ToString() : "Empty Watch";
        }

        private void UpdateOutput()
        {
            dataChanged?.Invoke();
        }
    }
}
