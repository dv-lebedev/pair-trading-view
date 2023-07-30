/*
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

namespace PairTradingView.Shared
{
    public class CsvSeparator
    {
        public string Name { get; }
        public char Value { get; }

        private CsvSeparator(string name, char value)
        {
            Check.NotNull(name, value);

            Name = name;
            Value = value;
        }

        public static readonly CsvSeparator Tab = new CsvSeparator(nameof(Tab), '\t');
        public static readonly CsvSeparator Comma = new CsvSeparator(nameof(Comma), ',');
        public static readonly CsvSeparator Space = new CsvSeparator(nameof(Space), ' ');

        public override string ToString()
        {
            return Name;
        }
    }
}
