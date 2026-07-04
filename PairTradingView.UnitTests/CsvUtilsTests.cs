/*
    Copyright(c) 2026 Denis Lebedev

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

using PairTradingView.Shared;

namespace PairTradingView.UnitTests;

public class CsvUtilsTests
{
    const int NumberOfPrices = 254;
    const int PriceIndex = 4;
    const bool ContainsHeader = false;

    [Test]
    public void Read_Test()
    {
        Stock lkoh = CsvUtils.Read("csv-files/LKOH.txt", priceIndex: PriceIndex, containsHeader: ContainsHeader);

        Assert.That(lkoh.Prices.Length, Is.EqualTo(NumberOfPrices));
        Assert.That(Math.Round(lkoh.Prices.First(), 2), Is.EqualTo(3421.5));
        Assert.That(Math.Round(lkoh.Prices.Last(), 2), Is.EqualTo(4997));
    }

    [Test]
    public void ReadAllDataFrom_Test()
    {
        Stock[] stocks = CsvUtils.ReadAllDataFrom("csv-files/", priceIndex: PriceIndex, containsHeader: ContainsHeader);

        Assert.That(stocks.Length, Is.EqualTo(8));

        foreach (var stock in stocks)
        {
            Assert.That(stock.Prices.Length, Is.EqualTo(NumberOfPrices));
        }
    }
}
