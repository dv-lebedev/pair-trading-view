
namespace PairTradingView.Logic.Synthetics
{
    public class FinancialPairName
    {
        public string X { get; private set; }
        public string Y { get; private set; }

        public FinancialPairName(string x, string y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            var item = obj as FinancialPairName;

            if (item == null)
            {
                return false;
            }

            return (X == item.X) && (Y == item.Y);
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public override string ToString()
        {
            return Y + "/" + X;
        }
    }
}
