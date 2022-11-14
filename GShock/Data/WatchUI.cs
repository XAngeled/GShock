using Watch;
using GShock.Data.ModeRenderers;
using Microsoft.AspNetCore.Components;

namespace GShock.Data
{
    public class WatchUI
    {
        public RenderFragment Output;
        public event Action? OutputHasChanged;
        private Watch.Watch _watch;
        private Dictionary<Type, BaseModeRenderer> _renderers;
        public WatchUI(Watch.Watch watch, Dictionary<Type, BaseModeRenderer> renderers)
        {
            _watch = watch;
            _renderers = renderers;
            if (_watch.CurrentMode != null)
            {
                Output = _renderers[_watch.CurrentMode.GetType()].Render();
            }
        }

        public void CycleMode()
        {
            _watch.CycleMode();
        }

    }
}
