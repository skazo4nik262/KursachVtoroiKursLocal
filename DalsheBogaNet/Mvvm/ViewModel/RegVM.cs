using DalsheBogaNet.Mvvm.Model;
using DalsheBogaNet.Mvvm.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DalsheBogaNet.Mvvm.ViewModel
{
    public class RegVM: BaseVM
    {
        public VmCommand Nazad {  get; set; }
        public VmCommand Registr {  get; set; }
        public Role SelectedRole { get; set; }
        public List<Role> Roles { get; set; }
        Action close;

        public RegVM()
        {
            Nazad = new VmCommand(() =>
            {
                Home();
            });
            Registr = new VmCommand(() =>
            {
                Registracia();
            });
        }

        private void Registracia()
        {
            if (SelectedRole == null)
                return;
            MainWindow main = new MainWindow();
            RegistWindow regist = new RegistWindow();

            var a = regist.tb.Text;
            var b = regist.pb.Password;
            if (a is null || b is null)
                MessageBox.Show("Похоже вы заполнили не все поля. Попробуйте ещё раз");
            UserZapolnenie.Instance.Regist(a, b, SelectedRole.ID);

            MessageBox.Show("Вы успешно зарегистрировались");
            close?.Invoke();
            main.Show();
        }

        private void Home()
        {
            MainWindow mainWindow = new MainWindow();
            close?.Invoke();
            mainWindow.Show();
        }
        internal void SetClose(Action close)
        {
            this.close = close;
        }
    }
}
