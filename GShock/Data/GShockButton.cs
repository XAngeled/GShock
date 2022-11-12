namespace GShock.Data
{
    public class GShockButton : IButton
    {
        public string Title { get; }

        private Action _pressAction;
        private List<KeyValuePair<TimeSpan, Action>> _releaseActions;
        private DateTime _pressTime;

        public GShockButton(
            string title,
            Action pressAction, 
            List<KeyValuePair<TimeSpan, Action>>? releaseActions = null)
        {
            _pressAction = pressAction;
            if (releaseActions != null)
                _releaseActions = releaseActions;
            else
                _releaseActions = new List<KeyValuePair<TimeSpan, Action>>();
            Title = title;
        }

        public void Press()
        {
            _pressTime = DateTime.Now;
            _pressAction();
        }

        public void Release()
        {
            TimeSpan releaseDelay = DateTime.Now - _pressTime;
            foreach (KeyValuePair<TimeSpan, Action> releaseAction in _releaseActions)
            {
                if (releaseAction.Key >= releaseDelay)
                    releaseAction.Value();
            }
        }
    }
}
