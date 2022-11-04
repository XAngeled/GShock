namespace Watch.Modes.Actions.TimeOffsetActions
{
    public class AddMinuteAction : IModeAction<TimeOffset>
    {
        public string Name { get; }

        public AddMinuteAction()
        {
            Name = "Add Minute";
        }
        public void Execute(TimeOffset data)
        {
            data.Offset += TimeSpan.FromMinutes(1);
        }
    }
}
