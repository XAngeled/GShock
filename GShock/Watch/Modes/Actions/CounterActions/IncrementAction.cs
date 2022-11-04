namespace Watch.Modes.Actions.CounterActions
{
    public class IncrementAction : IModeAction<Counter>
    {
        public string Name { get; set; }

        public IncrementAction()
        {
            Name = "Increment";
        }

        public void Execute(Counter data)
        {
            data.Increment();
        }
    }
}
