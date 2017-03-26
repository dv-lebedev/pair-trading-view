
/*
Copyright(c) 2015-2017 Denis Lebedev

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using PairTradingView.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PairTradingView.ConsoleApp
{
    class Program
    {
        private const string MarketDataDirectory = "";
        private const double Balance = 100000.00;

        private static string[] Symbols = { "GOOG", "IBM", "XOM" };

        static void Main(string[] args)
        {
            var marketData = CsvUtils.ReadAllDataFrom(MarketDataDirectory, 4, false);

            var selectedShares = marketData.ToList().FindAll((i) =>
            {
                foreach (var symbol in Symbols)
                {
                    if (i.Name == symbol)
                        return true;
                }
                return false;
            });

            var financialPairs = FinancialPair.CreateMany(selectedShares.ToArray());

            var riskManager = new RiskManager(financialPairs.ToArray(), Balance);
            riskManager.Calculate();

            DisplayResults(financialPairs);

            Console.WriteLine("PRESS 'ENTER' TO EXIT.");
            Console.ReadLine();
        }

        static void DisplayResults(IEnumerable<FinancialPair> pairs)
        {
            foreach(var pair in pairs)
            {
                var result = $"[{pair.Name}]\n";
                result += $"Weight={pair.Weight} TradeVolume={pair.TradeVolume}\n";
                result += $"{pair.X.Name}={pair.X.TradeVolume} {pair.Y.Name}={pair.Y.TradeVolume}\n";
                Console.WriteLine(result);
            }
        }
    }
}
