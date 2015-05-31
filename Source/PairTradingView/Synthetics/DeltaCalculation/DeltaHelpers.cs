using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace PairTradingView.Synthetics.DeltaCalculation
{
    public static class DeltaHelpers
    {
        public static IEnumerable<AbstractDelta> GetDeltaInstances()
        {
            var deltaInstnces = new List<AbstractDelta>();

            var values = Assembly.GetExecutingAssembly().GetTypes().Where(i => i.Name.EndsWith("Delta"));

            foreach(var deltaType in values.Where(i=>i.IsAbstract == false))
            {

                deltaInstnces.Add((AbstractDelta)Activator.CreateInstance(deltaType));

            }

            return deltaInstnces;
        }
    }
}
