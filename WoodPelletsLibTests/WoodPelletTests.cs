using Microsoft.VisualStudio.TestTools.UnitTesting;
using WoodPelletsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WoodPelletsLib.Tests
{
    [TestClass()]
    public class WoodPelletTests
    {
        [TestMethod()]
        //Testing with inside valid range values -> No exceptions expected 
        [DataRow("XX",100,3)]    //Brand min length limit, inclusive
        [DataRow("XXXXX",100,3)] 
        [DataRow("XXXXX",100,1)] //Quality lower valid limit, inclusive
        [DataRow("XXXXX",100,5)] //Quality lower valid limit, inclusive
        [DataRow("XXXXX",1,3)]   //Price lower valid limit, inclusive
        public void WoodPelletTest(string brand, int price, int quality)
        {
            //Only in valid range values expected
            WoodPellet wp = new WoodPellet(42, brand, price, quality);
            
            //If any exception encoutered (unexpected) -> test will NOT pass
            wp.Validate();

            //Id range is NOT tested just expect 42, ensures test coverage on property
            Assert.AreEqual(42, wp.Id);

            //Brand property should work in valid range, ensures test coverage on property
            Assert.AreEqual(brand, wp.Brand);

            //Price property should work in valid range, ensures test coverage on property
            Assert.AreEqual(price, wp.Price);

            //Quality property should work in valid range, ensures test coverage on property
            Assert.AreEqual(quality, wp.Quality);
        }

        [TestMethod()]
        //Test ToString properties with valid properties
        public void  ToStringTest()
        {
            //Define some valid property values
            int id = 42;
            int price = 100;
            int quality = 3;
            string brand = "Brand";
  
            //Only in range valid values expected
            WoodPellet wp = new WoodPellet(id, brand, price, quality);
            
            //Ensures test coverage on ToString method
            Assert.AreEqual<string>($"Id: {id}, Brand: {brand}, Price: {price}, Quality: {quality}", $"{wp}");
        }

        [TestMethod()]
        //Testing with too short values -> Outside valid range brand values  
        [DataRow("")]  
        [DataRow("x")] //Limit
        public void ValidateBrandTest(string brand)
        {
            //Test that we catch the expected exception
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new WoodPellet(42, brand, 100, 3).ValidateBrand());
        }

        [TestMethod()]
        //Testing with null value -> Outside valid range brand value
        public void ValidateBrandTest2()
        {
            //Test that we catch the expected exception
            Assert.ThrowsException<ArgumentNullException>(() => new WoodPellet(42, null, 100, 3).ValidateBrand());
        }

        [TestMethod()]
        //Testing with invalid values -> Outside valid range 'quality' values  
        [DataRow(-1)]
        [DataRow(0)]  //Limit
        [DataRow(6)]  //Limit
        [DataRow(42)]
        public void ValidateQualityTest(int quality)
        {
            //Test that we catch the expected exception
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new WoodPellet(42, "XXX", 100, quality).ValidateQuality());
        }

        [TestMethod()]
        //Testing with invalid values -> Outside valid range 'price' values  
        [DataRow(-42)]
        [DataRow(0)]  //Limit
        public void ValidatePriceTest(int price)
        {
            //Test that we catch the expected exception
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new WoodPellet(42, "XXX", price, 3).ValidatePrice());
        }
    }
}