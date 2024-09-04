using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskManager.Core;
using TaskManager.Models;

namespace TaskManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<TodoItem> TodoItems { get; set; } = [];

    private TodoItem? _selectedItem;
    public TodoItem? SelectedItem
    {
        get => _selectedItem;
        set => SetValue(ref _selectedItem, value);
    }

    public ICommand AddCommand { get; set; }

    public MainWindowViewModel()
    {
        TodoItems =
        [
            TodoItem.CreateMedium("Walk the dog","walk the dog in the park"),
        ];

        AddCommand = RelayCommand.Create(OnAdd);
    }

    public void OnAdd(object? parameters)
    {
        TodoItems.Add(TodoItem.CreateMedium( "task" + TodoItems.Count , "Task number " + TodoItems.Count));
    }
}