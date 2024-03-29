﻿/*
    Copyright(c) 2023 Denis Lebedev

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

using PairTradingView.Shared.Statistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PairTradingView.Shared
{
    public class RiskManager
    {
        private FinancialPair[] _pairs;
        private double[] _synthIndex;

        public double Balance { get; }

        public RiskManager(IEnumerable<FinancialPair> pairs, double balance)
        {
            Check.NotNull(pairs);

            if (balance < 0) throw new ArgumentException("[balance] can't have negative value.");

            _pairs = pairs.ToArray();
            Balance = balance;

            SetTradeVolumeToDefault();
            SetSynthIndex();
        }

        private void SetTradeVolumeToDefault()
        {
            foreach (var pair in _pairs)
            {
                pair.TradeVolume = 0;
                pair.X.TradeVolume = 0;
                pair.Y.TradeVolume = 0;
            }
        }

        private void SetSynthIndex()
        {
            _synthIndex = new double[_pairs.First().DeltaValues.Length];

            for (int i = 0; i < _pairs.First().DeltaValues.Length; i++)
            {
                double value = 0;

                for (int j = 0; j < _pairs.Length; j++)
                {
                    value += _pairs[j].DeltaValues[i];
                }

                _synthIndex[i] += (value / _pairs.Length);
            }
        }

        public void Calculate()
        {
            double summary = 0;

            foreach (var pair in _pairs)
            {
                var regression = new LinearRegression();
                regression.Compute(pair.DeltaValues, _synthIndex);

                pair.Weight = 1 / (1 + Math.Abs(regression.Beta));

                summary += pair.Weight;
            }

            foreach (var pair in _pairs)
            {
                pair.Weight = pair.Weight / summary;
                pair.TradeVolume = Balance * pair.Weight;
            }

            foreach (var pair in _pairs)
            {
                double beta = pair.Regression.Beta;
                double weight = 1.0 / (1.0 + Math.Abs(beta));

                pair.X.TradeVolume = pair.TradeVolume * (weight * Math.Abs(beta));
                pair.Y.TradeVolume = pair.TradeVolume * weight;
            }
        }
    }
}
