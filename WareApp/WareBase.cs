namespace WareApp
{
    public abstract class WareBase : IWare
    {
        public event EventHandler PriceAdded;

        public WareBase(string name, string category)
        {
            Name = name;
            Category = category;
        }

        public string Name { get; private set; }

        public string Category { get; private set; }

        public abstract void AddPrice(string  price);

        public abstract void AddPrice(double price);

        public abstract void AddPrice(float price);

        public abstract Statistics GetStatistics();

        protected List<float> prices = new List<float>();

        protected virtual void OnPriceAdded()
        {
            PriceAdded?.Invoke(this, EventArgs.Empty);  
        }


    }
}
