
namespace PairTradingView.Synthetics
{
    public class SyntheticName
    {
        public string X { get; private set; }
        public string Y { get; private set; }

        public SyntheticName(string x, string y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            var item = obj as SyntheticName;

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
