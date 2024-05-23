using DalsheBogaNet.Mvvm.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DalsheBogaNet.Mvvm.ViewModel
{
    public class MainVM : BaseVM
    {
        static MainVM instance;
        //public VmCommand Nazad;
        public static MainVM Instance => instance;
        //Action close;

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
        public VmCommand Search {  get; set; }

        public MainVM()
        {
            instance = this;

            //Nazad = new VmCommand(() =>
            //{
            //    Home();
            //});
            Search = new VmCommand(() =>
            {
                OpenSearch();
            });
            OpenSearch();
        }

        private void OpenSearch()
        {
            CurrentPage = new ListProducts();
        }
        //private void Home()
        //{
        //    MainWindow mainWindow = new MainWindow();
        //    close?.Invoke();
        //    mainWindow.Show();
        //    Window izdelia = Application.Current.Windows.OfType<Izdelia>().FirstOrDefault();
        //    izdelia?.Close();
        //}
        //internal void SetClose(Action close)
        //{
        //    this.close = close;
        //}
    }
}
