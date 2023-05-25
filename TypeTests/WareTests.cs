using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareApp;

namespace WareAppTests
{
    public class WareTests
    {
        [Fact]
        public void GetStatisticsOneCategory_CorrectStatstics()
        {
            var ware = new WareInMemory("shirt", "Clothes");
            ware.AddPrice(70);
            ware.AddPrice(30);

            var statistics = ware.GetStatistics();

            Assert.Equal(100, statistics.Sum);
            Assert.Equal(50, statistics.Avr);
            Assert.Equal(70, statistics.Max);
        }

        [Fact]
        public void GetStatisticsMultipleCategories_CorrectSum()
        {
            var ware1 = new WareInMemory("black shirt", "Clothes");
            ware1.AddPrice(70);
            ware1.AddPrice(30);

            var ware2 = new WareInMemory("flip flops", "Shoes");
            ware2.AddPrice(100);
            ware2.AddPrice(50);

            var ware3 = new WareInMemory("striped tie", "Others");
            ware3.AddPrice(20);
            ware3.AddPrice(30);

            var statistics = new Statistics();

            var statistics1 = ware1.GetStatistics();
            var statistics2 = ware2.GetStatistics();
            var statistics3 = ware3.GetStatistics();

            Assert.Equal(300, statistics1.Sum+statistics2.Sum+statistics3.Sum);

        }
    }
}
