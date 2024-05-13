using DalsheBogaNet.Mvvm.Model;
using DalsheBogaNet.Mvvm.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DalsheBogaNet.Mvvm.ViewModel
{
    public class SkanerVM : BaseVM
    {
        Code code = new Code();
        public VmCommand Otskanir {  get; set; }
        public VmCommand Scan {  get; set; }
        public SkanerVM()
        {
            Scan = new VmCommand(() =>
            {
                Scaner();
            });
            Otskanir = new VmCommand(() =>
            {
                Otskan();
            });
        }
        private void Scaner()
        {

            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            code.Codee = "";
            Random rnd = new Random();
            for (int i = 0; i < 13; i++)
            {
                if (i == 0)
                    code.Codee += a[rnd.Next(0, 9)] + " ";
                else if (i == 6)
                    code.Codee += a[rnd.Next(0,9)] + " ";
                else
                    code.Codee += a[rnd.Next(0, 9)];
            }
            MessageBox.Show($"Данные занесены: \n {code.Codee}");
            code.Codes.Add(code.Codee);
        }
        private void Otskan()
        {
            Otskanirovani.Instance.Show();
        }
    }
}
