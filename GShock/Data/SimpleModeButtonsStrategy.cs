using Watch.Modes;

namespace GShock.Data
{
    public class SimpleModeButtonsStrategy : IModeButtonsStrategy
    {
        public List<IButton> GetButtons(IMode mode)
        {
            List<IButton> buttons = new List<IButton>();
            for (int i = 0; i < mode.GetActions().Count; i++)
            {
                // We create a local variable so that when we call the lambda it doesn't use the final 'i' iteration, but instead the desired index.
                var index = i;
                var action = mode.GetActions()[index];
                buttons.Add(
                    new GShockButton(
                        action,
                        () => { mode.ActivateAction(index); }
                        )
                    );
            }
            return buttons;
        }
    }
}
