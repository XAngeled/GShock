using Microsoft.AspNetCore.Components;
using Watch.Modes;

namespace GShock.Data.ModeRenderers
{
    public class TimeModeRenderer : BaseModeRenderer<TimeMode>
    {
        private TimeMode _mode;
        public TimeModeRenderer(TimeMode mode)
        {
            _mode = mode;
        }
        public RenderFragment Render()
        {
            
        }
    }
}
