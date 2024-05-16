using DalsheBogaNet.Mvvm.Model;
using DalsheBogaNet.Mvvm.ViewModel;
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
            ((RegVM)DataContext).SetClose(Close);
            Roles = new List<Role>(UserZapolnenie.Instance.GetAllRoles());
        }

       
    }
}
