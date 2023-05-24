using System.Diagnostics;

namespace WareApp
{
    public class WareInMemory : WareBase
    {
        public override event PriceAddedDelegate PriceAdded;

        private List<float> prices = new List<float>();

        public WareInMemory(string name, string category)
            : base(name, category)
        {
        }

        public override void AddPrice(float price)
        {
            if (price > 0)
            {
                this.prices.Add(price);
                if (PriceAdded != null)
                {
                    PriceAdded(this, new EventArgs());
                }
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
                this.prices.Add((float)price);
                if (PriceAdded != null)
                {
                    PriceAdded(this, new EventArgs());
                }
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
