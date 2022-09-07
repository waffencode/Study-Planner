using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Study_Planner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Components.TasksCollection MainTasksCollection;
        public ObservableCollection<Components.Task> Tasks;

        public MainWindow()
        {
            InitializeComponent();
            MainTasksCollection = new Components.TasksCollection();
            Tasks = new ObservableCollection<Components.Task>();
            TasksList.DataContext = Tasks;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            Tasks.Add(MainTasksCollection.CreateTask(DescriptionField.Text));
        }

        private void ToggleCompleted_Click(object sender, RoutedEventArgs e)
        {
            Button ToggleCompletedButton = (Button)sender;
            Components.Task SelectedTask = (Components.Task)ToggleCompletedButton.DataContext;
            SelectedTask.ToggleCompletedState();
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            Button DeleteTaskButton = (Button)sender;
            Components.Task SelectedTask = (Components.Task)DeleteTaskButton.DataContext;
            Tasks.Remove(SelectedTask);
        }
    }
}
