using DalsheBogaNet.Mvvm.Model;
using DalsheBogaNet.Mvvm.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalsheBogaNet.Mvvm.ViewModel
{
    internal class SmsVM : BaseVM
    {
        private ObservableCollection<Zakaz> products;

        public VmCommand Okno { get; set; }


      

        //public Product SelectedProduct { get; set; }
        public ObservableCollection<Zakaz> Products
        {
            get => products;
            set
            {
                products = value;
                Signal();
            }
        }

        public SmsVM()
        {
            Okno = new VmCommand(() =>
            {
                MainVM.Instance.CurrentPage = new ListProducts();
            });
           

            string sql = "SELECT * FROM izdelia WHERE Amount <100";

            Products = new ObservableCollection<Zakaz>(ProductZapolnenie.Instance.GetAllZakaz(sql));

        }

    }
}
