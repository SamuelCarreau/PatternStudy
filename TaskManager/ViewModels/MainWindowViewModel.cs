using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskManager.Core;
using TaskManager.Models;

namespace TaskManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<TodoItemViewModel> TodoItems { get; set; } = [];

    private TodoItemViewModel? _selectedItem;
    public TodoItemViewModel? SelectedItem
    {
        get => _selectedItem;
        set => SetValue(ref _selectedItem, value);
    }

    public ICommand AddCommand { get; set; }

    public ICommand SaveCommand { get; set; }

    public ICommand CancelCommand { get; set; }

    public MainWindowViewModel()
    {
        AddCommand = RelayCommand.Create(OnAdd);
        SaveCommand = RelayCommand.Create(OnSave);
        CancelCommand = RelayCommand.Create(OnCancel);

        TodoItems =
        [
           new TodoItemViewModel(TodoItem.CreateMedium("Walk the dog","walk the dog in the park"),SaveCommand,CancelCommand),
        ];

    }

    public void OnAdd(object? parameters)
    {
        TodoItems.Add(new TodoItemViewModel(TodoItem.CreateMedium( "task" + TodoItems.Count , "Task number " + TodoItems.Count),SaveCommand,CancelCommand));
    }

    public void OnSave(object? parameters)
    {
        SelectedItem = null;
    }

    public void OnCancel(object? parameters)
    {
        SelectedItem = null;
    }
}