using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows.Controls;

namespace Study_Planner.Components
{
    public class TaskViewModel
    {
        public ObservableCollection<Task> Tasks { get; set; }

        private readonly string tasksFilePath = ConfigurationManager.AppSettings.Get("tasksFileName");

        private Command _addTaskCommand;
        public Command AddTaskCommand => _addTaskCommand ??= new Command(obj => Tasks.Add(new Task(Tasks.Count, obj as string)));

        private Command _toggleCompletedCommand;
        public Command ToggleCompletedCommand => _toggleCompletedCommand ??= new Command(obj => (obj as Task).ToggleCompletedState());

        private Command _deleteTaskCommand;
        public Command DeleteTaskCommand => _deleteTaskCommand ??= new Command(obj => Tasks.Remove(obj as Task));

        private Command _editTaskCommand;
        public Command EditTaskCommand => _editTaskCommand ??= new Command(obj => (obj as Task).ToggleEditState());

        private Command _saveTaskCommand;
        public Command SaveTaskCommand => _saveTaskCommand ??= new Command(obj =>
                                                       {
                                                           TextBox selectedBox = obj as TextBox;
                                                           Task selectedTask = selectedBox.DataContext as Task;
                                                           selectedTask.ShortDescription = selectedBox.Text;
                                                           selectedTask.ToggleEditState();
                                                       });

        public TaskViewModel() => Tasks = new ObservableCollection<Task>();

        public void OnProgramShutdown() => FileManager.SaveCollectionToFile(Tasks, tasksFilePath);

        public void OnProgramStartup() => FileManager.LoadCollectionFromFile(Tasks, tasksFilePath);
    }
}