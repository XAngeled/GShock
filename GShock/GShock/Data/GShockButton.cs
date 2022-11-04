namespace GShock.Data
{
    public class GShockButton : IButton
    {
        private Action _pressAction;
        private List<KeyValuePair<TimeSpan, Action>> _releaseActions;
        private DateTime _pressTime;

        public GShockButton(
            Action pressAction, 
            List<KeyValuePair<TimeSpan, Action>> releaseActions)
        {
            _pressAction = pressAction;
            _releaseActions = releaseActions;
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
