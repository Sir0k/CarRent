using CarRent.Entities;
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

namespace CarRent
{
    /// <summary>
    /// Логика взаимодействия для AddCar.xaml
    /// </summary>
    public partial class AddCar : Window
    {
        public AddCar()
        {
            InitializeComponent();
        }
        private void BackToCatalog()
        {
            var catalogPage = new Catalog();
            catalogPage.Show();
            this.Close();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            using (Context db = new Context())
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите добавить этот автомобиль?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    var car = new AvailableCars
                    {
                        brand = textBoxBrand.Text,
                        model = textBoxModel.Text,
                        engine = textBoxEngine.Text,
                        body = textBoxBody.Text,
                        color = textBoxColor.Text,
                        price_for_day = int.Parse(textBoxPriceForDay.Text),
                        availability = true
                    };
                    db.AvailableCars.Add(car);
                    db.SaveChanges();
                    MessageBox.Show("Автомобиль успешно добавлен");
                    BackToCatalog();
                }
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            BackToCatalog();
        }
    }
}
