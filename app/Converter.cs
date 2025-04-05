using JolpicaF1CSharp;
using System.Globalization;

namespace app
{
    public class FullNameConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is DriversData driver)
                return $"{driver.givenName} {driver.familyName}";
            return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class GrandPrixNameConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string raceName && raceName.Length > 13)
                return $"{raceName.Remove(raceName.Length - 11)} GP";
            return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class CircuitLocation : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is CircuitData circuit)
                return $"{circuit.circuitName}, {circuit.Location.locality}, {circuit.Location.country}";
            return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DriverCodeConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is DriversData driver)
                return $"{driver.permanentNumber} | {driver.code}";
            return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TimerFormatCovnerter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? paramter, CultureInfo culture)
        {
            if (value is string time && time.Length > 5)
                return time[..5];
            return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DateFormatCovnerter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? paramter, CultureInfo culture)
        {
            // yyyy-mm-dd
            if (value is string date && date.Length > 5)
                return $"{date[8..]} - {date[5..7]}";
            return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class CircuitPNGConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string circuitId)
                return $"{circuitId}.png";
            return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}