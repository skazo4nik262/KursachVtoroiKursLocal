using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для Otskanirovani.xaml
    /// </summary>
    public partial class Otskanirovani : Window
    {
        static Otskanirovani instance;
        public static Otskanirovani Instance
        {
            get
            {
                if (instance == null)
                    instance = new Otskanirovani();
                return instance;
            }
        }
        public Otskanirovani()
        {
            
            InitializeComponent();
        }
    }
}
