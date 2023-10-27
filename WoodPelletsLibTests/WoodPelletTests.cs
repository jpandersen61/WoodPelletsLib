using Microsoft.VisualStudio.TestTools.UnitTesting;
using WoodPelletsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodPelletsLib.Tests
{
    [TestClass()]
    public class WoodPelletTests
    {
        [TestMethod()]
        [DataRow("XX",3)]
        [DataRow("XXXXX", 3)]
        [DataRow("XXXXX", 1)]
        [DataRow("XXXXX", 5)]
        public void WoodPelletTest(string brand, int quality)
        {
            WoodPellet wp = new WoodPellet(42, brand, 100, quality);
            wp.Validate();
            Assert.AreEqual(42, wp.Id);
            Assert.AreEqual(brand, wp.Brand);
            Assert.AreEqual(100, wp.Price);
            Assert.AreEqual(quality, wp.Quality);
        }

        [TestMethod()]
        [DataRow("")]
        [DataRow("x")]
        public void ValidateBrandTest(string brand )
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new WoodPellet(42, brand, 100, 3).ValidateBrand());
        }

        [TestMethod()]
        public void ValidateBrandTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new WoodPellet(42, null, 100, 3).ValidateBrand());
        }

        [TestMethod()]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(6)]
        [DataRow(42)]
        public void ValidateQualityTest(int quality)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new WoodPellet(42, "XXX", 100, quality).ValidateQuality());
        }
    }
}