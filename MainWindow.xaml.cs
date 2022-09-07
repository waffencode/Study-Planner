using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Study_Planner.Components;

namespace Study_Planner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TasksCollection MainTasksCollection;
        public ObservableCollection<Task> Tasks;

        public MainWindow()
        {
            InitializeComponent();
            MainTasksCollection = new TasksCollection();
            Tasks = new ObservableCollection<Task>();
            TasksList.DataContext = Tasks;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            Tasks.Add(MainTasksCollection.CreateTask(DescriptionField.Text));
        }

        private void ToggleCompleted_Click(object sender, RoutedEventArgs e)
        {
            GetButtonDataContext((Button)sender).ToggleCompletedState();
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            Tasks.Remove(GetButtonDataContext((Button)sender));
        }

        private Task GetButtonDataContext(Button button)
        {
            return (Task)button.DataContext;
        }
    }
}
