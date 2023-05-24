namespace WareApp
{
    public abstract class WareBase : IWare
    {
        public delegate void PriceAddedDelegate(object senger, EventArgs args);

        public abstract event PriceAddedDelegate PriceAdded;

        public WareBase(string name, string category)
        {
            this.Name = name;
            this.Category = category;
        }

        public string Name { get; private set; }

        public string Category { get; private set; }

        public abstract void AddPrice(string  price);

        public abstract void AddPrice(double price);

        public abstract void AddPrice(float price);

        public abstract Statistics GetStatistics();


    }
}
