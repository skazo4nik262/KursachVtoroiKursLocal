using DalsheBogaNet.Mvvm.Model;
using DalsheBogaNet.Mvvm.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalsheBogaNet.Mvvm.ViewModel
{
    internal class SmsVM : BaseVM
    {
        public VmCommand Okno { get; set; }

        public SmsVM()
        {
            Okno = new VmCommand(() =>
            {
                MainVM.Instance.CurrentPage = new ListProducts();
            });

        }
    }
}
