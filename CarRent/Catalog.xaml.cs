using CarRent.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {

        string findText;
        int carId;

        public Catalog(bool v)
        {
            InitializeComponent();
            comboBoxSort.SelectedIndex = 0;
            Update();
            if (v == true)
            {
                buttonAddCar.Visibility = Visibility.Hidden;
                buttonDeleteCar.Visibility = Visibility.Hidden;
                buttonEditCar.Visibility = Visibility.Hidden;
            }
        }

        private List<AvailableCars> GetAvailableCars() => new Context().AvailableCars.ToList();

        //Поиск по названию
        private void TextSearch(object sender, TextChangedEventArgs e)
        {
            findText = searchText.Text;
            Update();
        }

        //Поиск по цене
        private void PriceSortChanged(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void checkBoxAvailable_Checked(object sender, RoutedEventArgs e)
        {
            Update();
        }
        private void checkBoxAvailable_Unchecked(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void Update()
        {
            var cars = GetAvailableCars();
            Sort(ref cars);
            CarList.ItemsSource = cars;
        }

        private void Sort(ref List<AvailableCars> cars)
        {
            AvailableSort(ref cars);
            NameSort(ref cars);
            PriceSort(ref cars);
        }

        private void AvailableSort(ref List<AvailableCars> listCars)
        {
            if (checkBoxAvailable.IsChecked == true) { listCars = listCars.Where(x => x.availability == true).ToList(); }
            else if (checkBoxAvailable.IsChecked == false) { listCars = listCars.ToList(); }
            
        }

        private void PriceSort(ref List<AvailableCars> listCars)
        {
            if (comboBoxSort.SelectedIndex == 0) { listCars = listCars.OrderBy(x => x.price_for_day).ToList(); }
            else if (comboBoxSort.SelectedIndex == 1) { listCars = listCars.OrderByDescending(x => x.price_for_day).ToList(); }   
        }

        private void NameSort(ref List<AvailableCars> listCars)
        {
            if (!string.IsNullOrEmpty(findText))
            {
                listCars = listCars.Where(x =>
                {
                    var brand = x.brand.ToLower();
                    var model = x.model.ToLower();
                    var search = findText.ToLower();
                    return brand.Contains(search) || model.Contains(search);
                }).ToList();
                
            }
        }

        private void CarList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarList.SelectedItem != null)
            {
                var selectedCar = (AvailableCars)CarList.SelectedItem;
                carId = selectedCar.ID_car;
            }
        }

        private void buttonAddCar_Click(object sender, RoutedEventArgs e)
        {
            var addCarPage = new AddCar();
            addCarPage.Show();
            this.Close();
        }

        private void buttonEditCar_Click(object sender, RoutedEventArgs e)
        {
            

            if (CarList.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите редактировать этот автомобиль?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    var editCarPage = new EditCar(carId);
                    editCarPage.Show();
                    this.Close();
                }
            }
            else { MessageBox.Show("Выберете автомобиль"); }
        }

        private void buttonDeleteCar_Click(object sender, RoutedEventArgs e)
        {
            using (Context db = new Context())
            {
                if (CarList.SelectedItem != null)
                {
                    var car = db.AvailableCars.Where(x => x.ID_car == carId).FirstOrDefault();
                    if (car != null)
                    {
                        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить этот автомобиль?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            db.AvailableCars.Remove(car);
                            db.SaveChanges();
                        }
                    }
                    Update();
                }
                else { MessageBox.Show("Выберете автомобиль"); }
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var toAuth = new MainWindow();
                toAuth.Show();
                this.Close();
            }
        }
    }
}
