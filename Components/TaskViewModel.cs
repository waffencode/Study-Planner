using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Study_Planner.Components
{
    public class TaskViewModel
    {
        public ObservableCollection<Task> Tasks { get; set; }
        public FileManager MainFileManager;

        private Command _addTaskCommand;
        public Command AddTaskCommand
        {
            get
            {
                return _addTaskCommand ??= new Command(obj =>
                {
                    string description = obj as string;
                    Tasks.Add(new Task(Tasks.Count, description));
                });
            }
        }

        private Command _toggleCompletedCommand;
        public Command ToggleCompletedCommand
        {
            get
            {
                return _toggleCompletedCommand ??= new Command(obj =>
                {
                    Task selectedTask = obj as Task;
                    selectedTask.ToggleCompletedState();
                });
            }
        }

        private Command _deleteTaskCommand;
        public Command DeleteTaskCommand
        {
            get
            {
                return _deleteTaskCommand ??= new Command(obj =>
                {
                    Task selectedTask = obj as Task;
                    Tasks.Remove(selectedTask);
                });
            }
        }

        private Command _editTaskCommand;
        public Command EditTaskCommand
        {
            get
            {
                return _editTaskCommand ??= new Command(obj =>
                {
                    Task selectedTask = obj as Task;
                    selectedTask.ToggleEditState();
                });
            }
        }

        private Command _saveTaskCommand;
        public Command SaveTaskCommand
        {
            get
            {
                return _saveTaskCommand ??= new Command(obj =>
                {
                    TextBox selectedBox = obj as TextBox;
                    Task selectedTask = (Task)selectedBox.DataContext;
                    selectedTask.ShortDescription = selectedBox.Text;
                    selectedTask.ToggleEditState();
                });
            }
        }

        public TaskViewModel()
        {
            Tasks = new ObservableCollection<Task>();
            MainFileManager = new FileManager();
        }

        public void OnWindowClose()
        {
            MainFileManager.SaveTasksToFile(Tasks);
        }

        public void OnProgramStartup()
        {
            MainFileManager.LoadTasksFromFile(Tasks);
        }
    }
}