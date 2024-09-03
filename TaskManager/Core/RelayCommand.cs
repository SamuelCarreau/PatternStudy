using System.Windows.Input;

namespace TaskManager.Core;

//https://learn.microsoft.com/en-us/archive/msdn-magazine/2009/february/patterns-wpf-apps-with-the-model-view-viewmodel-design-pattern
public class RelayCommand : ICommand
{
    readonly Action<object?> _execute;
    readonly Predicate<object?>? _canExecute;

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove {  CommandManager.RequerySuggested -= value;}
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute == null ? true : _canExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        _execute(parameter);
    }
    private RelayCommand(Action<object?> execute) : this(execute, null) { }
    private RelayCommand(Action<object?> execute, Predicate<object?>? canExecute)
    {
        ArgumentNullException.ThrowIfNull(execute,nameof(execute));
        _execute = execute; _canExecute = canExecute;
    }

    public static RelayCommand Create(Action<object?> onExecute)
    {
        return new RelayCommand(onExecute);
    }

    public static RelayCommand Create(Action<object?> onExecute, Predicate<object?>? canExecute)
    {
        return new RelayCommand(onExecute, canExecute);
    }
}
