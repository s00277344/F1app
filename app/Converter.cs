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
}
