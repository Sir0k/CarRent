using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Data.SqlClient;
using CarRent.Entities;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace CarRent
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _login, _password;
        bool disableButtons = false;
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ToCatalog() 
        {
            var catalogPage = new Catalog(disableButtons);
            catalogPage.Show();
            this.Close();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            _login = loginText.Text;
            _password = passwordText.Password;

            var worker = new Entities.Context().Workers.Where(x => x.login == _login && x.password == _password).FirstOrDefault();


            if (loginText.Text == "" || passwordText.Password == "") { MessageBox.Show("Введите все данные"); return; }

            if (worker == null) { MessageBox.Show("Пользователь не найден"); return; }

            else if (worker != null)
            {
                MessageBox.Show("Вы вошли как " + worker.role.ToString());
            }
            ToCatalog();
        }

        private void CatalougeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы вошли как гость");
            disableButtons = true; 
            ToCatalog();
        }
    }
}
