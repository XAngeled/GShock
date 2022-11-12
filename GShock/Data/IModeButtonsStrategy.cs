using Watch.Modes;

namespace GShock.Data
{
    public interface IModeButtonsStrategy
    {
        List<IButton> GetButtons(IMode mode);
    }
}