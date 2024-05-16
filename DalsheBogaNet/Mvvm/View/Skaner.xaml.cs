using DalsheBogaNet.Mvvm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DalsheBogaNet.Mvvm.View
{
    /// <summary>
    /// Логика взаимодействия для Skaner.xaml
    /// </summary>
    public partial class Skaner : Window
    {
        public Skaner()
        {
            InitializeComponent();
            ((SkanerVM)DataContext).SetClose(Close);
            MessageBox.Show("На данный момент эта функция может работать не правильно");
        }
    }
}
