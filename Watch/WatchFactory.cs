using Utilities;
using Watch.Modes;
using Watch.Modes.Actions;
using Watch.Modes.Actions.CounterActions;
using Watch.Modes.Actions.ClockActions;

namespace Watch
{
    public class WatchFactory
    {
        public static Watch Build()
        {
            return new Watch(new List<IMode>
            {
                new TimeMode(
                    new Clock(new TimeOffset()),
                    new List<IModeAction<Clock>>
                    {
                        new AddSecondAction(),
                        new AddMinuteAction(),
                        new AddHourAction()
                    },
                    10
                    ),
                new CounterMode(
                    new List<IModeAction<Counter>>
                    {
                        new IncrementAction(),
                        new ResetAction()
                    },
                    new Counter())
            });
        }
    }
}
