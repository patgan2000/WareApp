namespace WareApp
{
    public class WareInFile : WareBase
    {
        public override event PriceAddedDelegate PriceAdded;

        private const string fileName = "wares.txt";

        public WareInFile(string name, string category)
            :base(name, category)
        {
        }

        public override void AddPrice(float price)
        {
            if (price > 0)
            {
                this.prices.Add(price);
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine($"{price}");
                    if (PriceAdded != null)
                    {
                        PriceAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new Exception("Invalid price value.");
            }
        }

        public override void AddPrice(double price)
        {
            float floatPrice = (float)price;
            this.AddPrice(floatPrice);
        }

        public override void AddPrice(string price)
        {
            if (float.TryParse(price, out float result))
            {
                this.AddPrice(result);
            }
            else
            {
                if (price.Length > 1)
                {
                    throw new Exception("String is not float");
                }
                else
                {
                    this.AddPrice(price[0]);
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = CountStatistic(prices);
            return result;
        }

        private List<float> ReadPricesFromFile()
        {
            var prices = new List<float>();
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        prices.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return prices;
        }

        private Statistics CountStatistic(List<float> prices)
        {
            var statistics = new Statistics();

            foreach (var price in ReadPricesFromFile())
            {
                statistics.AddPrice(price);
            }

            return statistics;
        }
    }
}
