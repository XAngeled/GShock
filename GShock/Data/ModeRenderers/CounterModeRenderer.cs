using GShock.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Watch.Modes;

namespace GShock.Data.ModeRenderers
{
    public class CounterModeRenderer : BaseModeRenderer
    {
        private CounterMode _mode;
        private SimpleModeButtonsStrategy _buttonsStrategy;
        public CounterModeRenderer(CounterMode mode)
        {
            _mode = mode;
            _buttonsStrategy = new SimpleModeButtonsStrategy();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.OpenElement(1, "h2");
            builder.AddContent(2, _mode.CounterData.ToString());
            builder.CloseElement();
            builder.OpenComponent(3, typeof(ModeButtons));
            builder.AddAttribute(4, "Buttons",_buttonsStrategy.GetButtons(_mode));
            builder.CloseComponent();
            builder.CloseElement();
        }
    }
}
