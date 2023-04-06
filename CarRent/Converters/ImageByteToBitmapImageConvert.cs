using CarRent.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace CarRent.Converters
{
    internal class ImageByteToBitmapImageConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Byte[] bytes = value as Byte[];
            if (bytes == null)
            {
                return new BitmapImage(new Uri("/Resources/no-image.jpg", UriKind.Relative));
            }
            return Helper.LoadImageFromData((byte[])value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
