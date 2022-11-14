using Utilities;
namespace Watch.Modes.Actions.ClockActions
{
    public class AddSecondAction : IModeAction<Clock>
    {
        public string Name { get; }

        public AddSecondAction()
        {
            Name = "Add Second";
        }
        public void Execute(Clock data)
        {
            data.ModifyTime(TimeSpan.FromSeconds(1));
        }
    }
}
