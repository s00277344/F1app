using JolpicaF1CSharp;
using System.Globalization;

namespace app
{
    public class FullNameConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is DriversData driver)
                return $"{driver.givenName} {driver.familyName}";
            return string.Empty;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TimerFormatCovnerter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? paramter, CultureInfo culture)
        {
            if (value is string time && time.Length > 5)
                return time[..5];
            return string.Empty;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
