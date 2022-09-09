using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Study_Planner.Components;

namespace Study_Planner
{
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Task> _tasks = new ObservableCollection<Task>();

        public MainWindow()
        {
            InitializeComponent();
            TasksList.DataContext = _tasks;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            _tasks.Add(new Task(_tasks.Count, DescriptionField.Text));
        }

        private void ToggleCompleted_Click(object sender, RoutedEventArgs e)
        {
            GetButtonTaskContext(sender).ToggleCompletedState();
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            _tasks.Remove(GetButtonTaskContext(sender));
        }

        private Task GetButtonTaskContext(object button)
        {
            return (Task)((Button)button).DataContext;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
