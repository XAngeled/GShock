using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Watch.Modes;

namespace GShock.Data.ModeRenderers
{
    public class TimeModeRenderer
    {
        private TimeMode _mode;
        public TimeModeRenderer(TimeMode mode)
        {
            _mode = mode;
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.OpenElement(1, "h2");
            builder.AddContent(2, _mode.Time.ToString());
            builder.CloseElement();
            builder.CloseElement();
        }
    }
}
