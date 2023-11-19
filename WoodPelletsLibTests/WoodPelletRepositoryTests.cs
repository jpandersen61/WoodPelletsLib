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
    public class WoodPelletRepositoryTests
    {
        void AddSomeWoodPellets(WoodPelletRepository wpr)
        {
            wpr.Add(new WoodPellet(1, "BioWood", 4995,4));
            wpr.Add(new WoodPellet(2, "BioWood", 5195, 4));
            wpr.Add(new WoodPellet(3, "BilligPille", 4125, 1));
            wpr.Add(new WoodPellet(4, "GoldenWoodPellet", 5995, 1));
            wpr.Add(new WoodPellet(5, "GoldenWoodPellet", 5795, 5));
        }

        [TestMethod()]
        public void GetAllTest()
        {
            WoodPelletRepository wpr = new WoodPelletRepository();
            
            List<WoodPellet> list =  wpr.GetAll();
            
            Assert.IsNotNull(list);
            Assert.AreEqual(0, list.Count);            
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            WoodPelletRepository wpr = new WoodPelletRepository();
            AddSomeWoodPellets(wpr);
            List<WoodPellet> list = wpr.GetAll();
            List<WoodPellet> fetchedList = wpr.GetById(list[0].Id);
            Assert.IsNotNull(fetchedList);
            Assert.AreEqual(1, fetchedList.Count);
            Assert.AreEqual(list[0].Id, fetchedList[0].Id);
            Assert.AreEqual(list[0].Price, fetchedList[0].Price);
            Assert.AreEqual(list[0].Quality, fetchedList[0].Quality);
            Assert.AreEqual(list[0].Brand, fetchedList[0].Brand);
        }

        [TestMethod()]
        public void AddTest()
        {
            WoodPelletRepository wpr = new WoodPelletRepository();

            AddSomeWoodPellets(wpr);

            List<WoodPellet> list = wpr.GetAll();

            Assert.IsNotNull(list);
            Assert.AreEqual(5, list.Count);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            WoodPelletRepository wpr = new WoodPelletRepository();
            AddSomeWoodPellets(wpr);
            List<WoodPellet> list = wpr.GetAll();
            List<WoodPellet> fetchedList = wpr.GetById(list[0].Id);
            
            WoodPellet wpFetched = fetchedList[0];
            wpFetched.Price += 1;
            wpFetched.Brand +="(brand)";
            
            wpr.Update(wpFetched);

            List<WoodPellet> updatedList = wpr.GetById(wpFetched.Id);

            Assert.AreEqual(wpFetched.Price, updatedList[0].Price);
            Assert.AreEqual(wpFetched.Price, updatedList[0].Price);
            Assert.AreEqual(wpFetched.Quality, updatedList[0].Quality);

        }
    }
}