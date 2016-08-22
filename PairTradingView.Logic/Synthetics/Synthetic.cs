
#region LICENSE

/*
Copyright(c) 2015-2016 Denis Lebedev

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

#endregion


using PairTradingView.Data;
using PairTradingView.Logic.Synthetics.RiskManagement;
using Statistics;
using System;
using System.Collections.Generic;

namespace PairTradingView.Logic.Synthetics
{
    public abstract class Synthetic : DataChannel
    {
        public string Name { get; protected set; }

        public IRegression Regression { get; protected set; }

        public RiskParameters RiskParameters { get; protected set; }

        public decimal[] DeltaValues { get; protected set; }

        public virtual decimal DeltaValue { get; protected set; }

        public string[] Symbols { get; protected set; }

        public decimal[] StdDevs { get; protected set; }

        public Synthetic(InputData[] inputData)
        {
            if (inputData == null) throw new ArgumentNullException("inputData");

            Initialize(inputData);
        }

        protected abstract void Initialize(InputData[] inputData);

        public abstract void SetRiskParameters(RiskParameters riskParameters);

        public abstract void StockInfoUpdated(IEnumerable<StockInfo> stockInfo);
    }
}
