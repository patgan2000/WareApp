using System.Diagnostics;

namespace WareApp
{
    public class WareInMemory : WareBase
    {
        public WareInMemory(string name, string category)
            : base(name, category)
        {
        }

        public override void AddPrice(float price)
        {
            if (price > 0)
            {
                prices.Add(price);
                OnPriceAdded();
            }
            else
            {
                throw new Exception("Invalid price value.");
            }
        }

        public override void AddPrice(double price)
        {
            if (price > 0)
            {
                prices.Add((float)price);
                OnPriceAdded();
            }
            else
            {
                throw new Exception("Invalid price value.");
            }
        }

        public override void AddPrice(string price)
        {
            if (float.TryParse(price, out float result))
            {
                this.AddPrice(result);
            }
            else
            {
                throw new Exception("This is not a float value. Try again.");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            foreach(var price in this.prices)
            {
                statistics.AddPrice(price);
            }
            return statistics;
        }
    }
}
