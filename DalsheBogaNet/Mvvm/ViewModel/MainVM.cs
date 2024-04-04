using DalsheBogaNet.Mvvm.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DalsheBogaNet.Mvvm.ViewModel
{
    public class MainVM : BaseVM
    {
        private Page currentPage;

        public Page CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                Signal();
            }
        }


    }
}
