using DalsheBogaNet.Mvvm.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DalsheBogaNet.Mvvm.View
{
    /// <summary>
    /// Логика взаимодействия для EditorProduct.xaml
    /// </summary>
    public partial class EditorProduct : Page
    {
        public EditorProduct(ViewModel.MainVM mainVM)
        {
            InitializeComponent();
            var vm = ((EditorProductVM)DataContext);
            vm.SetMainVM(mainVM);
        }
        public EditorProduct(MainVM mainVM, Product selectedProduct) : this(mainVM)
        {
            ((EditorProductVM)DataContext).SetEditProduct(selectedProduct);
        }
    }
}
