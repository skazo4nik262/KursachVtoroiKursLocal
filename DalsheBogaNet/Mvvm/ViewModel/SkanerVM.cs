using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DalsheBogaNet.Mvvm.ViewModel
{
    public class SkanerVM : BaseVM
    {
        public VmCommand Scan {  get; set; }
        public SkanerVM()
        {
            Scan = new VmCommand(() =>
            {
                Scaner();
            });
        }
        private void Scaner()
        {
            MessageBox.Show("Данные занесены");
        }
    }
}
