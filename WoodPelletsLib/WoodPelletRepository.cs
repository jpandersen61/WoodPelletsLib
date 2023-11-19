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
            int nextID = 1;
            if (woodPellets.Count > 0)
            {
                nextID = woodPellets.Max<WoodPellet>(w => w.Id) + 1;      
            }

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
