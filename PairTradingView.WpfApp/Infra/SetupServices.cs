using Microsoft.Extensions.DependencyInjection;
using PairTradingView.Shared;
using PairTradingView.WpfApp.Models;
using PairTradingView.WpfApp.ViewModels;
using Serilog;

namespace PairTradingView.WpfApp.Infra;

public static class SetupServices
{
    public static void AddAsOneServices(this ServiceCollection container)
    {
        // fin
        container.AddSingleton<Balance>(b => new Balance { Value = 100_000.00 });
        container.AddSingleton<Risk>();

        // logging
        container.AddSingleton<ILogger>((sp) => Log.Logger);

        // data
        container.AddSingleton<IStockDataProvider, StockDataProvider>();

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