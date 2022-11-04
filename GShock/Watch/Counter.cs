namespace Watch
{
    public class Counter
    {
        private int _counter;

        public void Increment()
        {
            _counter++;
        }
        public void Reset()
        {
            _counter = 0; 
        }
        public override string ToString()
        {
            return _counter.ToString();
        }
    }
}
