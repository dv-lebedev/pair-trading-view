using System.ComponentModel;

namespace PairTradingView.WpfApp.Models;

public partial class Param<T> : INotifyPropertyChanged
{
    private T? _value;

    public T? Value
    {
        get { return _value; }
        set
        {
            if (!EqualityComparer<T>.Default.Equals(_value, value))
            {
                _value = value;
                ValueChanged?.Invoke(this, EventArgs.Empty);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }
    }

    public event EventHandler ValueChanged;
    public event PropertyChangedEventHandler? PropertyChanged;
}
