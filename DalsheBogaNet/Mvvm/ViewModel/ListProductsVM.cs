using DalsheBogaNet.Mvvm.Model;
using DalsheBogaNet.Mvvm.View;
using System.Collections.ObjectModel;
using System.Windows;

namespace DalsheBogaNet.Mvvm.ViewModel
{
    public class ListProductsVM : BaseVM
    {
        private MainVM mainVM;
        private ProductZapolnenie productZapolnenie;
        private string searchText = "";
        private ObservableCollection<Product> products;


        public VmCommand Create { get; set; }
        public VmCommand Edit { get; set; }
        public VmCommand Delete { get; set; }


        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                Search();
            }
        }

        public Product SelectedProduct { get; set; }
        public ObservableCollection<Product> Products
        {
            get => products;
            set
            {
                products = value;
                Signal();
            }
        }


        public ListProductsVM()
        {
            string sql = "SELECT Tovar_ID, Name, Description, Price, Size, Breakable, Postavhik, Amount FROM izdelia";

            Products = new ObservableCollection<Product>(ProductZapolnenie.Instance.GetAllProducts(sql));



            Create = new VmCommand(() =>
            {
                mainVM.CurrentPage = new EditorProduct(mainVM);
            });

            Edit = new VmCommand(() =>
            {
                if (SelectedProduct == null)
                    return;
                else
                {
                    mainVM.CurrentPage = new EditorProduct(mainVM, SelectedProduct);
                }
            });
            Delete = new VmCommand(() =>
            {
                if (SelectedProduct == null)
                    return;
                if (MessageBox.Show("Удалить изделие?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ProductZapolnenie.Instance.Remove(SelectedProduct);
                    Products.Remove(SelectedProduct);
                }
            });
        }
        private void Search()
        {
            Products = new ObservableCollection<Product>(
                ProductZapolnenie.Instance.Search(SearchText));

        }

        internal void SetMainVM(MainVM mainVM)
        {
            this.mainVM = mainVM;
        }
    }
}
