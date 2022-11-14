using Utilities;
using Watch.Modes;

namespace GShock.Data.ModeRenderers
{
    public class ModeRendererFactory
    {
        public Dictionary<Type, BaseModeRenderer> ModeRenderers;
        public ModeRendererFactory(Dictionary<Type, BaseModeRenderer> modeRenderers)
        {
            ModeRenderers = modeRenderers;
        }
    }
}
