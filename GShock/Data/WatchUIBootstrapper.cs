using Utilities;
using Watch.Modes.Actions.ClockActions;
using Watch.Modes.Actions.CounterActions;
using Watch.Modes.Actions;
using Watch.Modes;
using Watch;
using GShock.Data.ModeRenderers;

namespace GShock.Data
{
    public class WatchUIBootstrapper
    {
        private TimeMode GetTimeMode()
        {
            return new TimeMode(
                new Clock(new TimeOffset()),
                new List<IModeAction<Clock>>
                {
                    new AddSecondAction(),
                    new AddMinuteAction(),
                    new AddHourAction()
                },
                10
            );
        }

        private CounterMode GetCounterMode()
        {
            return new CounterMode(
                new List<IModeAction<Counter>>
                {
                    new IncrementAction(),
                    new ResetAction()
                },
                new Counter());
        }

        public WatchUI Bootstrap()
        {
            var timeMode = GetTimeMode();
            var counterMode = GetCounterMode();

            var watch = new Watch.Watch(new List<IMode>()
            {
                timeMode,
                counterMode
            });
            var watchUI = new WatchUI(
                watch, 
                new Dictionary<Type, BaseModeRenderer>()
                {
                    { typeof(TimeMode), new TimeModeRenderer(timeMode) },
                    { typeof(CounterMode), new CounterModeRenderer(counterMode) }
                }
            );
            return watchUI;
        }
    }
}
