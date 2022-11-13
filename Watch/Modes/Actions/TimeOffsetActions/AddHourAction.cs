using Utilities;

namespace Watch.Modes.Actions.TimeOffsetActions
{
    public class AddHourAction : IModeAction<TimeOffset>
    {
        public string Name { get; }

        public AddHourAction()
        {
            Name = "Add Hour";
        }
        public void Execute(TimeOffset data)
        {
            data.Offset += TimeSpan.FromHours(1);
        }
    }
}
