using Utilities;
namespace Watch.Modes.Actions.TimeOffsetActions
{
    public class AddSecondAction : IModeAction<TimeOffset>
    {
        public string Name { get; }

        public AddSecondAction()
        {
            Name = "Add Second";
        }
        public void Execute(TimeOffset data)
        {
            data.Offset += TimeSpan.FromSeconds(1);
        }
    }
}
