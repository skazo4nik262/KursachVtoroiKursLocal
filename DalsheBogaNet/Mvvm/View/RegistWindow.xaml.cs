using DalsheBogaNet.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для RegistWindow.xaml
    /// </summary>
    public partial class RegistWindow : Window
    {
        public List<Role> Roles { get; set; }
        public Role SelectedRole { get; set; }
        public RegistWindow()
        {
            InitializeComponent();
            Roles = new List<Role>( UserZapolnenie.Instance.GetAllRoles());
            DataContext = this;
        }

        private void Regist_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedRole == null) 
                return;
            MainWindow main = new MainWindow();

            var a = tb.Text;
            var b = pb.Password;

            UserZapolnenie.Instance.Regist(a, b, SelectedRole.ID);

            MessageBox.Show("Вы успешно зарегистрировались");
            Hide();
            main.Show();
        }
    }
}
