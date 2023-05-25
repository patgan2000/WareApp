using WareApp;

namespace WareAppTests
{
    public class TypeTests
    {
        [Fact]
        public void VarAsReferenceType()
        {
            var ware1 = new WareInMemory("black shirt", "Clothes");
            var ware2 = new WareInMemory("black shirt", "Clothes");

            Assert.NotSame(ware1, ware2);

        }
        [Fact]
        public void AddInvalidPriceGetException()
        {
            var ware = new WareInFile("Black shirt", "Clothes");
            float price = -15f;

            Assert.Throws<Exception>(() => ware.AddPrice(price));
        }
    }
}