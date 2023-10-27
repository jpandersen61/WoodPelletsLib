using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodPelletsLib
{
    public class WoodPelletRepository
    {
        List<WoodPellet> woodPellets = new List<WoodPellet>();

        public WoodPelletRepository()
        {
            woodPellets.Add(new WoodPellet(1, "BioWood", 4995,4));
            woodPellets.Add(new WoodPellet(2, "BioWood", 5195, 4));
            woodPellets.Add(new WoodPellet(3, "BilligPille", 4125, 1));
            woodPellets.Add(new WoodPellet(4, "GoldenWoodPellet", 5995, 1));
            woodPellets.Add(new WoodPellet(5, "GoldenWoodPellet", 5795, 5));
        }

        public List<WoodPellet> GetAll()
        {
            return new List<WoodPellet>(woodPellets);
        }
        
        public List<WoodPellet> GetById(int id)
        {
            return new List<WoodPellet>(woodPellets).FindAll(w => w.Id == id);
        }   
        
        public void Add(WoodPellet wp)
        {
            int nextID = woodPellets.Max<WoodPellet>(w => w.Id);
            wp.Id = nextID;
            woodPellets.Add(wp);
        }
        
        public void Update(WoodPellet wp)
        {
            WoodPellet found = woodPellets.Find(w => w.Id == wp.Id);
            if (found != null)
            {
                found.Price = wp.Price;
                found.Quality = wp.Quality;
                found.Brand = wp.Brand;
            }
        }

    }
}
