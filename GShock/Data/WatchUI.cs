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
            _watch.dataChanged += UpdateOutput;
            if (_watch.CurrentMode != null)
            {
                Output = _renderers[_watch.CurrentMode.GetType()].Render();
                OutputHasChanged?.Invoke();
            }
        }

        public void CycleMode()
        {
            _watch.CycleMode();
            if (_watch.CurrentMode != null)
            {
                Output = _renderers[_watch.CurrentMode.GetType()].Render();
                OutputHasChanged?.Invoke();
            }
        }

        public void UpdateOutput()
        {
            if (_watch.CurrentMode != null)
            {
                Output = _renderers[_watch.CurrentMode.GetType()].Render();
                OutputHasChanged?.Invoke();
            }
        }
    }
}
