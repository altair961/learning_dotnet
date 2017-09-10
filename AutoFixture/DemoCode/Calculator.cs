namespace DemoCode
{
    public class Calculator
    {
        public int Value { get; private set; }

        public void Substract(int Number)
        {
            Value -= Number;
        }
    }
}
