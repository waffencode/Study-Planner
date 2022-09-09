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
