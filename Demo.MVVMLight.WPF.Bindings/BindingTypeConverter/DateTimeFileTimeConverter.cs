namespace Demo.MVVMLight.WPF.Bindings.BindingTypeConverter
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class DateTimeFileTimeConverter : IValueConverter
    {
        #region Methods

        //当值从绑定源传播给绑定目标时，调用方法Convert
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object result = null;
            if (value == null|| !TryConvert(value, targetType,out result))
            {
                return DependencyProperty.UnsetValue;
            }
            return result;
        }

        //当值从绑定目标传播给绑定源时，调用此方法ConvertBack
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object result = null;
            if (value == null || !TryConvert(value, targetType, out result))
            {
                return DependencyProperty.UnsetValue;
            }
            return result;
        }

        public bool TryConvert(object from, Type toType, out object result)
        {
            result = null;

            if (from.GetType() == typeof(DateTime))
            {
                var dt = (DateTime)from;
                result = dt.ToFileTime();
                return true;
            }
            else if (from.GetType() == typeof(long))
            {
                var dt = (long)from;
                result = DateTime.FromFileTime(dt);
                return true;
            }

            return false;
        }

        #endregion Methods
    }
}