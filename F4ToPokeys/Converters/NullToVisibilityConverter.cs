﻿using System;
using System.Windows.Data;
using System.Globalization;
using System.Windows;

namespace F4ToPokeys.Converters
{
    public class NullToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Membres
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? NullVisibility : NotNullVisibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion

        public Visibility NullVisibility { get; set; }
        public Visibility NotNullVisibility { get; set; }
    }
}
