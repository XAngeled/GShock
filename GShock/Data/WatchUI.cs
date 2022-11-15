using Watch;
using GShock.Data.ModeRenderers;
using Microsoft.AspNetCore.Components;

namespace GShock.Data
{
    public class WatchUI
    {
        public RenderFragment Output;
        public event Action? OutputHasChanged;
        public Watch.Watch WatchToShow;
        private Dictionary<Type, BaseModeRenderer> _renderers;
        public WatchUI(Watch.Watch watch, Dictionary<Type, BaseModeRenderer> renderers)
        {
            WatchToShow = watch;
            _renderers = renderers;
            WatchToShow.dataChanged += UpdateOutput;
            if (WatchToShow.CurrentMode != null)
            {
                Output = _renderers[WatchToShow.CurrentMode.GetType()].Render();
                OutputHasChanged?.Invoke();
            }
        }

        public void CycleMode()
        {
            WatchToShow.CycleMode();
            if (WatchToShow.CurrentMode != null)
            {
                Output = _renderers[WatchToShow.CurrentMode.GetType()].Render();
                OutputHasChanged?.Invoke();
            }
        }

        public void UpdateOutput()
        {
            if (WatchToShow.CurrentMode != null)
            {
                Output = _renderers[WatchToShow.CurrentMode.GetType()].Render();
                OutputHasChanged?.Invoke();
            }
        }
    }
}
