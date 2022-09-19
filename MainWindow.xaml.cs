using Study_Planner.Components;
using System.Windows;

namespace Study_Planner
{
    public partial class MainWindow : Window
    {
        public TaskViewModel MainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            MainViewModel = this.DataContext as TaskViewModel;
            MainViewModel.OnProgramStartup();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.OnProgramShutdown();
            Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
