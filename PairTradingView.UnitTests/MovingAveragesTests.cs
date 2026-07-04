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

using PairTradingView.Shared.Statistics;

namespace PairTradingView.UnitTests;

public class MovingAveragesTests
{
    [Test]
    public void SMATest()
    {
        double[] values = { 1, 3, 5, 7, 9, 2, 4, 6, 8, 11, 13, 15, 24, 46, 68 };

        try
        {
            var smaResult = MovingAverages.SMA(values, 0);
        }
        catch (ArgumentException ex)
        {
            Assert.That(ex.Message, Is.EqualTo("period <= 0"));
        }


        try
        {
            var result = MovingAverages.SMA(values, values.Length + 1);
        }
        catch (ArgumentException ex)
        {
            Assert.That(ex.Message, Is.EqualTo("period > values.Lenght"));
        }


        var sma5Result = MovingAverages.SMA(values, 5);

        double[] expectedValues = { 5, 5.2, 5.4, 5.6, 5.8, 6.2, 8.4, 10.6, 14.2, 21.8, 33.2 };

        Assert.That(sma5Result.Length, Is.EqualTo(expectedValues.Length));

        for (int i = 0; i < expectedValues.Length; i++)
        {
            Assert.That(sma5Result[i], Is.EqualTo(expectedValues[i]).Within(0.01));
        }
    }

    [Test]
    public void WMATest()
    {
        double[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5 };

        try
        {
            var smaResult = MovingAverages.WMA(values, 0);
        }
        catch (ArgumentException ex)
        {
            Assert.That(ex.Message, Is.EqualTo("period <= 0"));
        }


        try
        {
            var result = MovingAverages.WMA(values, values.Length + 1);
        }
        catch (ArgumentException ex)
        {
            Assert.That(ex.Message, Is.EqualTo("period > values.Lenght"));
        }


        var wma3Result = MovingAverages.WMA(values, 3);

        double[] expectedValues = { 2.33, 3.33, 4.33, 5.33, 6.33, 7.33, 8.33, 4.83, 2.83, 2.33, 3.33, 4.33 };

        Assert.That(wma3Result.Length, Is.EqualTo(expectedValues.Length));

        for (int i = 0; i < wma3Result.Length; i++)
        {
            Assert.That(wma3Result[i], Is.EqualTo(expectedValues[i]).Within(0.01));
        }
    }

    [Test]
    public void VMATest()
    {
        double[] values = { 11, 15, 19, 13, 14, 16, 23, 25, 29, 26, 35, 45 };
        long[] volumes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        Assert.That(values.Length, Is.EqualTo(volumes.Length));

        try
        {
            var smaResult = MovingAverages.VMA(values, volumes, 0);
        }
        catch (ArgumentException ex)
        {
            Assert.That(ex.Message, Is.EqualTo("period <= 0"));
        }


        try
        {
            var smaResult = MovingAverages.VMA(values, new long[] { 1, 3, 5 }, -1);
        }
        catch (ArgumentException ex)
        {
            Assert.That(ex.Message, Is.EqualTo("values.Length != volumes.Length"));
        }


        try
        {
            var result = MovingAverages.VMA(values, volumes, values.Length + 1);
        }
        catch (ArgumentException ex)
        {
            Assert.That(ex.Message, Is.EqualTo("period > values.Lenght"));
        }


        var sresult = MovingAverages.VMA(values, volumes, 4);

        double[] expectedValues = { 15, 14.9285, 15.2777, 17.2272, 20.2692, 23.9333, 25.9411, 29.1052, 34.4285 };

        Assert.That(sresult.Length, Is.EqualTo(expectedValues.Length));

        for (int i = 0; i < expectedValues.Length; i++)
        {
            Assert.That(sresult[i], Is.EqualTo(expectedValues[i]).Within(0.01));
        }
    }
}