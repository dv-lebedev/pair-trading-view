
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

public class PairInfo
{
    public string Name { get; set; }
    public bool Selected { get; set; }
    public string X { get; set; }
    public string Y { get; set; }
    public decimal SD_X { get; set; }
    public decimal SD_Y { get; set; }
    public decimal Alpha { get; set; }
    public decimal Beta { get; set; }
    public decimal R { get; set; }
    public decimal RSquared { get; set; }
    public decimal DeltaAverage { get; set; }
    public decimal DeltaMin { get; set; }
    public decimal DeltaMax { get; set; }
    public decimal DeltaSD { get; set; }
    public decimal DeltaSDMinus3Q { get; set; }
    public decimal DeltaSDPlus3Q { get; set; }  
}