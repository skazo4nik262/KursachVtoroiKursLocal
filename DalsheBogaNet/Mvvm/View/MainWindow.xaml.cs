using DalsheBogaNet.Mvvm.View;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DalsheBogaNet
{
    // Автоматизация учета изделий на предприятии
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Vhod_click(object sender, RoutedEventArgs e)
        {
            if (tb1.Text == "123" && tb2.Text == "123")
            {
                Izdelia izdelia = new Izdelia();
                Close();
                izdelia.Show();
            }
        }
    }
}