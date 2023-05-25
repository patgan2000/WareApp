namespace WareApp
{
    public class Statistics
    {
        public float Max { get; private set; }

        public float Sum { get; private set; }

        public int Count { get; private set; }

        public float Avr
        {
            get
            {
                return Sum / Count;
            }
        }

        public Statistics()
        {
            Count = 0;
            Sum = 0;
            Max = 0;
        }

        public void AddPrice(float price)
        {
            Count++;
            Sum += price;
            Max = Math.Max(this.Max, price);
        }
    }
}
