using Microsoft.AspNetCore.Components;
using Watch.Modes;

namespace GShock.Data
{
    public class ModeButtonsFactory
    {
        Dictionary<Type, IModeButtonsStrategy> ButtonStrategies { get; set; }
        public ModeButtonsFactory(Dictionary<Type, IModeButtonsStrategy> buttonStrategies)
        {
            ButtonStrategies = buttonStrategies;
        }

        public List<IButton> GetButtons(IMode mode)
        {
            return ButtonStrategies[mode.GetType()].GetButtons(mode);
        }
    }
}
