using Utilities;

namespace Watch.Modes.Actions.ClockActions
{
    public class AddMinuteAction : IModeAction<Clock>
    {
        public string Name { get; }

        public AddMinuteAction()
        {
            Name = "Add Minute";
        }
        public void Execute(Clock data)
        {
            data.ModifyTime(TimeSpan.FromMinutes(1));
        }
    }
}
