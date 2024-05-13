using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalsheBogaNet.Mvvm.Model
{
    internal class Zakaz
    {
        public int ID { get; set; } 
        public string Desc { get; set; } = "Товар заканчивается";
        public string Name { get; set; }
        public int Postav { get; set; }
    }
}
