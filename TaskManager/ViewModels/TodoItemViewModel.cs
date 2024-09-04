using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    public class TodoItemViewModel
    {
        public TodoItem TodoItem { get; set; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public TodoItemViewModel(TodoItem item, ICommand saveCommand, ICommand cancelCommand)
        {
            TodoItem = item;
            SaveCommand = saveCommand;
            CancelCommand = cancelCommand;
        }
    }
}
