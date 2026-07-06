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

public class RiskManagerTests
{
    [Test]
    public void CalculateTest()
    {
        Stock[] stocks = CsvUtils.ReadAllDataFrom("csv-files/", 4, false);

        var pairs = FinancialPair.CreateMany<FinancialPair>(stocks);

        var rm = new RiskManager(pairs.ToArray(), 100000.00);
        rm.Calculate();

        pairs.ForEach(i => { Assert.That(Math.Round(i.TradeVolume, 1), Is.Not.EqualTo(0)); });

        Assert.That(Math.Round(pairs.Select(i => i.TradeVolume).Sum(), 2), Is.EqualTo(100000.00).Within(0.01));

        Assert.That(Math.Round(pairs.Select(i => i.Weight).Sum(), 2), Is.EqualTo(1));
    }
}