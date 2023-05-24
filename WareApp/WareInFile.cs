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
            using (var writer = File.AppendText(fileName))
            {
                if(price>0)
                {
                    writer.WriteLine($"{Category} {Name} {price}");
                    if(PriceAdded!=null)
                    {
                        PriceAdded(this, new EventArgs());
                    }
                }
                else
                {
                    throw new Exception("Invalid price value.");
                }
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
            var pricesFromFile = ReadPricesFromFile();
            var result = CountStatistic(pricesFromFile);
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
                    while ((line = reader.ReadLine()) != null)
                    {
                        var data = line.Split(' ');
                        if (data.Length == 3)
                        {
                            var category = data[0];
                            var name = data[1];
                            var price = float.Parse(data[2]);
                            if (category == Category && name == Name)
                            {
                                prices.Add(price);
                            }
                        }
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
