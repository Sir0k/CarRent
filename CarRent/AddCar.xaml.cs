using CarRent.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
using static System.Net.Mime.MediaTypeNames;

namespace CarRent
{
    /// <summary>
    /// Логика взаимодействия для AddCar.xaml
    /// </summary>
    public partial class AddCar : Window
    {
        private string _pathToImage = null;
        bool _isSuccessfulImageLoaded = false;
        bool _isEdit = false;


        public AddCar(AvailableCars availableCar)
        {
            InitializeComponent();
            Car = availableCar;
            if (Car != null)
            {
                textBoxBrand.Text = Car.brand;
                textBoxModel.Text = Car.model;
                textBoxEngine.Text = Car.engine;
                textBoxBody.Text = Car.body;
                textBoxColor.Text = Car.color;
                textBoxPriceForDay.Text = Car.price_for_day.ToString();
                ImagePreview.Source = Car.ImageData != null ? Helper.LoadImageFromData(Car.ImageData) : new BitmapImage(new Uri("/Resources/no-image.jpg", UriKind.Relative));

                _isEdit = true;
                
            }
            else
            {
                Car = new AvailableCars();
            }
            
        }

        
        public AvailableCars Car { get; set; }



        private void BackToCatalog()
        {
            var catalogPage = new Catalog(false);
            catalogPage.Show();
            this.Close();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            using (Context db = new Context())
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите сохранить этот автомобиль?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if ( _isEdit == false) 
                {
                    if (result == MessageBoxResult.Yes)
                    {
                        Car.brand = textBoxBrand.Text;
                        Car.model = textBoxModel.Text;
                        Car.engine = textBoxEngine.Text;
                        Car.body = textBoxBody.Text;
                        Car.color = textBoxColor.Text;
                        Car.price_for_day = int.Parse(textBoxPriceForDay.Text);
                        Car.availability = true;
                        Car.ImageData = _isSuccessfulImageLoaded == true ? File.ReadAllBytes(_pathToImage) : null;

                        db.AvailableCars.Add(Car);
                        db.SaveChanges();
                        MessageBox.Show("Автомобиль успешно сохранен");
                        BackToCatalog();
                    }
                }
                else
                {
                    //var car = db.AvailableCars.Where(x => x.ID_car == editCarId).FirstOrDefault();
                    if (result == MessageBoxResult.Yes)
                    {
                        Car.brand = textBoxBrand.Text;
                        Car.model = textBoxModel.Text;
                        Car.engine = textBoxEngine.Text;
                        Car.body = textBoxBody.Text;
                        Car.color = textBoxColor.Text;
                        Car.price_for_day = int.Parse(textBoxPriceForDay.Text);
                        Car.availability = true;
                        Car.ImageData = _isSuccessfulImageLoaded == true ? File.ReadAllBytes(_pathToImage) : null;
                        db.Entry(Car).State = EntityState.Modified; 
                        db.SaveChanges();

                        MessageBox.Show("Автомобиль успешно изменен");
                        BackToCatalog();
                    }
                }

            }
        }
        private async Task LoadImageAsync(string path)
        {
            if (!File.Exists(path)) 
            {
                _isSuccessfulImageLoaded = false;
                return; 
            }
            BitmapImage previewImg = new BitmapImage();
            previewImg.BeginInit();
            
            previewImg.UriSource = new Uri(path);
            previewImg.EndInit();

            ImagePreview.Source = previewImg;
            _pathToImage = path;
            _isSuccessfulImageLoaded = true;
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

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            BackToCatalog();
        }
    }
}
