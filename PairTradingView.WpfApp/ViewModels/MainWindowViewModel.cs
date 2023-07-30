using PairTradingView.Infrastructure;
using PairTradingView.WpfApp.Models;
using PairTradingView.WpfApp.Views;
using System.Windows.Controls;

namespace PairTradingView.WpfApp.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly UserControl FilesLoaderView = new FilesLoaderView();
        private readonly UserControl MainView = new MainView();
        private readonly FinancialPairsModel Model = FinancialPairsModel.Instance;

        private object _currentView;

        public object CurrentView
        {
            get => _currentView;

            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            CurrentView = FilesLoaderView;

            Model.PairsChanged += (s, e) => CurrentView = MainView;
        }
    }
}
