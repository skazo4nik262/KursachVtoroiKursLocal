using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalsheBogaNet.Mvvm.Model
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Size { get; set; }
        public bool Breakable { get; set; }
        public int Postavhik {  get; set; }
        public int Amount { get; set; }
    }
}
