using PairTradingView.WpfApp.ViewModels;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PairTradingView.WpfApp.Converters
{
    internal class RiskLimitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SelectedPairInfoViewModel vm)
            {
                return Math.Round((vm.PairsTradeVolume * vm.Risk / 100.0), 4).ToString();
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
