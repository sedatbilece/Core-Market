using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Data.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName{ get; set; }
        public string Desc{ get; set; }
        public double Price{ get; set; }
        public string ImageURL{ get; set; }
        public int Stock { get; set; }

        // bire çok ilişkedde tekli taraf food yani bir tane category alıyor
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }




    }
}
