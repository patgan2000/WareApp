namespace WareApp
{
    public class WareInFile : WareBase
    {
        private const string fileName = "wares.txt";

        public WareInFile(string name, string category)
            :base(name, category)
        {
        }

        public override void AddPrice(float price)
        {
            if (price > 0)
            {
                prices.Add(price);
                WritePriceToFile(price);
                OnPriceAdded();
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
                AddPrice(result);
            }
            else
            {
                if (price.Length > 1)
                {
                    throw new Exception("String is not float");
                }
                else
                {
                    if(float.TryParse(price,out float singleCharPrice))
                    {
                        AddPrice(singleCharPrice);
                    }
                    else
                    {
                        throw new Exception("Invalid price value.");
                    }
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var pricesFromFile = ReadPricesFromFile();
            var statistics = new Statistics();

            foreach(var price in pricesFromFile)
            {
                statistics.AddPrice(price);
            }
            return statistics;
        }

        private void WritePriceToFile(float price)
        {
            using(var writer = File.AppendText(fileName))
            {
                writer.WriteLine(price.ToString());
            }
        }

        public List<float> ReadPricesFromFile()
        {
            var prices = new List<float>();
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        if(float.TryParse(line, out float number))
                        {
                            prices.Add(number);
                        }
                    }
                }
            }
            return prices;
        }
    }
}
