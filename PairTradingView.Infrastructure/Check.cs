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

using System;

namespace PairTradingView.Shared
{
    public static class Check
    {
        public static void NotNull(params object[] items)
        {
            foreach(var item in items)
            {
                if (item == null)
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public static void ThrowIfNullOrEmpty(string value, string propertyName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (value == string.Empty)
            {
                throw new ArgumentException(nameof(propertyName));
            }
        }
    }
}
