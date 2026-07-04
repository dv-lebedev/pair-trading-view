using Microsoft.Extensions.DependencyInjection;
using PairTradingView.WpfApp.Models;
using PairTradingView.WpfApp.ViewModels;
using Serilog;

namespace PairTradingView.WpfApp.Infra;

public static class SetupServices
{
    public static void AddAsOneServices(this ServiceCollection container)
    {
        container.AddSingleton<ILogger>((sp) => Log.Logger);

        // view models
        container.AddSingleton<FinancialPairsModel>();
        container.AddSingleton<MainWindowViewModel>();
        container.AddSingleton<MainViewModel>();
        container.AddSingleton<FilesLoaderViewModel>();
        container.AddSingleton<SelectedPairInfoViewModel>();
        container.AddSingleton<ChartViewModel>();
        container.AddSingleton<GeneralTableViewModel>();        
    }
}
