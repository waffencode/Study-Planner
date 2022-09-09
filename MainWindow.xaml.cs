using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Study_Planner.Components;

namespace Study_Planner
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Task> Tasks;

        public MainWindow()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<Task>();
            TasksList.DataContext = Tasks;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            Tasks.Add(new Task(Tasks.Count, DescriptionField.Text));
        }

        private void ToggleCompleted_Click(object sender, RoutedEventArgs e)
        {
            GetButtonTaskContext(sender).ToggleCompletedState();
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            Tasks.Remove(GetButtonTaskContext(sender));
        }

        private Task GetButtonTaskContext(object button)
        {
            return (Task)((Button)button).DataContext;
        }
    }
}
