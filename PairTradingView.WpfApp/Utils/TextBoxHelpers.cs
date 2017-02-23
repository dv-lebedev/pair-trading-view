
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

using System;
using System.Globalization;
using System.Windows.Controls;

namespace PairTradingView.WpfApp
{
    public static class TextBoxHelpers
    {
        public static int GetInt32(this TextBox textBox)
        {
            int result;

            if(!int.TryParse(textBox.Text, out result))
            {
                throw new Exception($"{textBox.Name} has incorrect value.");
            }

            return result;
        }

        public static double GetDouble(this TextBox textBox)
        {
            double result;

            if (!double.TryParse(textBox.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result))
            {
                throw new Exception($"{textBox.Name} has incorrect value.");
            }

            return result;
        }
    }
}
