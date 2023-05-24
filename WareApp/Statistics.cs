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
                return this.Sum / this.Count;
            }
        }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Max = 0;
        }

        public void AddPrice(float price)
        {
            this.Count++;
            this.Sum += price;
            this.Max = Math.Max(this.Max, price);
        }
    }
}
