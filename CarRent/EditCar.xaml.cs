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
    /// Логика взаимодействия для EditCar.xaml
    /// </summary>
    public partial class EditCar : Window
    {
        int editCarId;
        public EditCar(int carId)
        {
            InitializeComponent();
            editCarId = carId;
            Update();
        }

        private void Update()
        {
            using (Context db = new Context())
            {
                var car = db.AvailableCars.Where(x => x.ID_car == editCarId).FirstOrDefault();
                if (car != null)
                {
                    textBoxBrand.Text = car.brand;
                    textBoxModel.Text = car.model;
                    textBoxEngine.Text = car.engine;
                    textBoxBody.Text = car.body;
                    textBoxColor.Text = car.color;
                    textBoxPriceForDay.Text = car.price_for_day.ToString();
                }
            }
        }

        private void BackToCatalog()
        {
            var catalogPage = new Catalog(false);
            catalogPage.Show();
            this.Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            BackToCatalog();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            using (Context db = new Context())
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите изменить этот автомобиль?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var car = db.AvailableCars.Where(x => x.ID_car == editCarId).FirstOrDefault();

                    car.brand = textBoxBrand.Text;
                    car.model = textBoxModel.Text;
                    car.engine = textBoxEngine.Text;
                    car.body = textBoxBody.Text;
                    car.color = textBoxColor.Text;
                    car.price_for_day = int.Parse(textBoxPriceForDay.Text);
                    db.SaveChanges();

                    MessageBox.Show("Автомобиль успешно изменен");
                    BackToCatalog();
                }
            }
        }

        private async Task LoadImageAsync(string path)
        {
            BitmapImage previewImg = new BitmapImage();
            previewImg.BeginInit();
            previewImg.UriSource = new Uri(path);
            previewImg.EndInit();

            ImagePreview.Source = previewImg;
        }

        private async void ButtonLoadImage_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                await LoadImageAsync(openFileDialog.FileName);
            }
        }
    }
}
