using Utilities;

namespace Watch.Modes.Actions.ClockActions
{
    public class AddHourAction : IModeAction<Clock>
    {
        public string Name { get; }

        public AddHourAction()
        {
            Name = "Add Hour";
        }
        public void Execute(Clock data)
        {
            data.ModifyTime(TimeSpan.FromHours(1));
        }
    }
}
