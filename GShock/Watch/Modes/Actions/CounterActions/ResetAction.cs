namespace Watch.Modes.Actions.CounterActions
{
    public class ResetAction : IModeAction<Counter>
    {
        public string Name { get; set; }

        public ResetAction()
        {
            Name = "Reset";
        }

        public void Execute(Counter data)
        {
            data.Reset();
        }
    }
}
