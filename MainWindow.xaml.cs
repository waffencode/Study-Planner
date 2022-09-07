using Study_Planner.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
