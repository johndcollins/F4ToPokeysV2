using System;
using System.Windows.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace F4ToPokeys.Converters
{
    public class ConnectedColorConverter : MarkupExtension, IValueConverter
    {
        public Brush TrueBrush { get; set; }
        public Brush FalseBrush { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToBoolean(value) ? TrueBrush : FalseBrush;
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
