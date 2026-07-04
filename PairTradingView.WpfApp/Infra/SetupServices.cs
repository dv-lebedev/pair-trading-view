using Microsoft.Extensions.DependencyInjection;
using PairTradingView.WpfApp.Models;
using PairTradingView.WpfApp.ViewModels;

namespace PairTradingView.WpfApp.Infra;

public static class SetupServices
{
    public static void AddAsOneServices(this ServiceCollection container)
    {
        // viewmodels
        container.AddSingleton<FinancialPairsModel>();
        container.AddSingleton<MainWindowViewModel>();
        container.AddSingleton<MainViewModel>();
        container.AddSingleton<FilesLoaderViewModel>();
        container.AddSingleton<SelectedPairInfoViewModel>();
        container.AddSingleton<ChartViewModel>();
        container.AddSingleton<GeneralTableViewModel>();        
    }
}
