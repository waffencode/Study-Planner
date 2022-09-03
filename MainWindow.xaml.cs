using System;
using System.Collections.Generic;
using System.Linq;
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
        public MainWindow()
        {
            InitializeComponent();

            MainTasksCollection = new Components.TasksCollection();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            MainTasksCollection.Debug_CreateTask(DescriptionField.Text);
            TasksList.ItemsSource = MainTasksCollection.tasksList.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
