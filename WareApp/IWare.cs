using static WareApp.WareBase;

namespace WareApp
{
    public interface IWare
    {
        string Name { get; }

        string Category { get; }

        void AddPrice(string pricee);

        void AddPrice(float price);

        void AddPrice(double price);

        Statistics GetStatistics();

        event PriceAddedDelegate PriceAdded;
    }
}
