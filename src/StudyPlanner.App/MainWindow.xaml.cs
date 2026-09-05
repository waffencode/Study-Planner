using StudyPlanner.App.Components;
using System.Windows;

namespace StudyPlanner.App
{
    /// <summary>
    /// Главное окно приложения. Получает модель представления через DI и устанавливает её как <see cref="FrameworkElement.DataContext"/>.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Создаёт окно и устанавливает <see cref="TaskViewModel"/> из контейнера как <see cref="FrameworkElement.DataContext"/>.
        /// Загрузка сохранённых задач выполняется командой <c>InitializeCommand</c> по событию <c>Loaded</c> (см. MainWindow.xaml).
        /// </summary>
        /// <param name="taskViewModel">Модель представления списка задач.</param>
        public MainWindow(TaskViewModel taskViewModel)
        {
            InitializeComponent();
            DataContext = taskViewModel;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();

        private void MinimizeButton_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
    }
}
