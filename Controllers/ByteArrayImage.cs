﻿using System.Globalization;

namespace AutoresGrupo5.Controllers
{
    internal class ByteArrayImage : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            ImageSource? imageSource = null;
            if (value != null)
            {
                byte[] imageByte = (byte[])value;
                var stream = new MemoryStream(imageByte);
                imageSource = ImageSource.FromStream(() => stream);
            }

            return imageSource;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
