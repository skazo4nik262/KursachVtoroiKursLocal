using DalsheBogaNet.Mvvm.Model;
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
        UserZapolnenie userZapolnenie = new UserZapolnenie();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Vhod_click(object sender, RoutedEventArgs e)
        {
            string a = tb1.Text;
            string b = tb2.Password;
            {
                userZapolnenie.GetUserData(a, b);
                if (userZapolnenie.Vhod == true)
                {
                    if (userZapolnenie.GetUserData(a, b).Role == "Бухгалтер")
                    {
                        Izdelia izdelia = new Izdelia();
                        Close();
                        izdelia.Show();
                    }
                    else if (userZapolnenie.GetUserData(a, b).Role == "Администратор")
                    {
                        RegistWindow regist = new RegistWindow();
                        Close();
                        regist.Show();
                    }
                    else
                    {
                        Skaner skaner = new Skaner();
                        Close();
                        skaner.Show();
                    }
                }
                else
                {
                    MessageBox.Show("FFFFFFFFFFFFFFFFFFFFFFFFFFF");
                }
            }

        }

        private void Regist_Click(object sender, RoutedEventArgs e)
        {
            RegistWindow reg = new RegistWindow();
            Hide();
            reg.Show();
        }
    }
}