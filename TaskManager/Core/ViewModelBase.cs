using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskManager.Core;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    protected void SetValue<T>(ref T field, T value, [CallerMemberName] string? name = null)
    {
        field = value;
        OnPropertyChanged(name);
    }
}
