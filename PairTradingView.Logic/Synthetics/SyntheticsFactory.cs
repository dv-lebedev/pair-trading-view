/*
Copyright 2015 Denis Lebedev

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

using PairTradingView.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PairTradingView.Logic.Synthetics
{
    public abstract class SyntheticsFactory
    {
        protected InputData[] values;

        public SyntheticsFactory(InputData[] values)
        {
            if (values == null) throw new ArgumentNullException("values");

            this.values = values;
        }

        public abstract IEnumerable<Synthetic> CreateSynthetics();

        public static SyntheticsFactory LoadByName(string shortName, InputData[] values)
        {
            var type = Assembly.GetAssembly(typeof(SyntheticsFactory))
                .GetTypes()
                .Where(i=> i.BaseType == (typeof(SyntheticsFactory)) && 
                i.Name.StartsWith(shortName)).First();

            return (SyntheticsFactory)Activator.CreateInstance(type, new object[] { values });
        }

        public static string[] GetFactoriesNames()
        {
            var type = Assembly.GetAssembly(typeof(SyntheticsFactory)).GetTypes().Where(i => !i.IsAbstract);

            return type
                .Select(i => i.Name)
                .Where(j => j.EndsWith("SyntheticsFactory"))
                .Select(k => k.Replace("SyntheticsFactory", "")).ToArray();
        }
    }
}
