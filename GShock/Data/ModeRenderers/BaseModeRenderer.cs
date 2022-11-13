using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Watch.Modes;

namespace GShock.Data.ModeRenderers
{
    public abstract class BaseModeRenderer<TMode> where TMode : IMode
    {
        protected abstract void BuildRenderTree(RenderTreeBuilder builder);
        public RenderFragment Render()
        {
            RenderFragment fragment = (b) =>
            {
                BuildRenderTree(b);
            };
            return fragment;
        }
    }
}
