using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalsheBogaNet.Mvvm.Model
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public string Size { get; set; }
        public bool Breakable { get; set; }
    }
}
