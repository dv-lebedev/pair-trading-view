using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTradingView.Synthetics
{
    public class Delta
    {
        public static double[] GetDeltaValues(double[] x, double[] y, 
            double beta, double correlation, DeltaType delta)
        {
            switch (delta)
            {
                case DeltaType.Ratio:
                    {
                        if (correlation >= 0)
                        {
                            return x.Zip(y, (i, j) => j / i).ToArray();
                        }
                        else
                        {
                            return x.Zip(y, (i, j) => Math.Log10(j) * Math.Log10(i)).ToArray();
                        }
                    }

                case DeltaType.RatioIncludingBeta:
                    {
                        if (correlation >= 0)
                        {
                            return x.Zip(y, (i, j) => j / (Math.Abs(beta) * i)).ToArray();
                        }
                        else
                        {
                            return x.Zip(y, (i, j) => Math.Log10(j) * Math.Log10(Math.Abs(beta) * i)).ToArray();
                        }

                    }

                case DeltaType.Spread:
                    {
                        if (correlation >= 0)
                        {
                            return x.Zip(y, (i, j) => j - i).ToArray();
                        }
                        else
                        {
                            return x.Zip(y, (i, j) => j + i).ToArray();
                        }
                    }

                case DeltaType.SpreadIncludingBeta:
                    {
                        if (correlation >= 0)
                        {
                            return x.Zip(y, (i, j) => j - Math.Abs(beta) * i).ToArray();
                        }
                        else
                        {
                            return x.Zip(y, (i, j) => j + Math.Abs(beta) * i).ToArray();
                        }
                    }

                default:
                    return null;
            }
            
        }

        public static double GetCurrentDelta(double x, double y, 
            double beta, double correlation, DeltaType delta)
        {
            switch (delta)
            {
                case DeltaType.Ratio:
                    {
                        if (correlation >= 0)
                        {
                            return y / x;
                        }
                        else
                        {
                            return  Math.Log10(y) * Math.Log10(x);
                        }
                    }

                case DeltaType.RatioIncludingBeta:
                    {
                        if (correlation >= 0)
                        {
                            return y / (Math.Abs(beta) * x);
                        }
                        else
                        {
                            return  Math.Log10(y) * Math.Log10(Math.Abs(beta) * x);
                        }

                    }

                case DeltaType.Spread:
                    {
                        if (correlation >= 0)
                        {
                            return y - x;
                        }
                        else
                        {
                            return  y + x;
                        }
                    }

                case DeltaType.SpreadIncludingBeta:
                    {
                        if (correlation >= 0)
                        {
                            return  y - Math.Abs(beta) * x;
                        }
                        else
                        {
                            return  y + Math.Abs(beta) * x;
                        }
                    }

                default:
                    throw new ArgumentException();
            }

        }
    }
}
