using DalsheBogaNet.Mvvm.Model;
using DalsheBogaNet.Mvvm.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;

namespace DalsheBogaNet.Mvvm.ViewModel
{
    public class SkanerVM : BaseVM
    {
        Code code = new Code();
        public VmCommand Otskanir {  get; set; }
        public VmCommand Scan {  get; set; }
        public VmCommand Nazad { get; set; }
        private ObservableCollection<Code> codees;
        Action close;
        public SkanerVM()
        {
            string sql = "SELECT Code From Codes";

            Codes = new ObservableCollection<Code>(ProductZapolnenie.Instance.GetAllCode(sql));

            Scan = new VmCommand(() =>
            {
                Scaner();
            });
            Otskanir = new VmCommand(() =>
            {
                Otskan();
            });
            Nazad = new VmCommand(() =>
            {
                Home();
            });
        }
        public ObservableCollection<Code> Codes
        {
            get => codees;
            set
            {
                codees = value;
                Signal();
            }
        }

        private void Home()
        {
            MainWindow mainWindow = new MainWindow();
            close?.Invoke();
            mainWindow.Show();
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
            ProductZapolnenie.Instance.AddCode(code);
            //code.Codes.Add(code.Codee);

            //Codees.Add(code.Codee);

            //foreach (var i in code.Codes)
            //{
            //    MessageBox.Show("kjdfhfkjdh" + i);
            //}
            //MessageBox.Show($"Данные занесены: \n {code.Codee}");
        }
        private void Otskan()
        {
            //MessageBox.Show("Данная функция в настоящий момент времени не работает.");
            Otskanirovani otskanirovani = new Otskanirovani();
            otskanirovani.Show();
        }
        internal void SetClose(Action close)
        {
            this.close = close;
        }
    }
}
