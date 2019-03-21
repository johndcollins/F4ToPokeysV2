using System;
using System.Windows.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace F4ToPokeys.Converters
{
    public class ConnectedValueConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToBoolean(value) ? Translations.Main.FalconConnected : Translations.Main.FalconDisconnected;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
