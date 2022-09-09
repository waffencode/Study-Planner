using System.Collections.ObjectModel;

namespace Study_Planner.Components
{
    public class TaskViewModel
    {
        public ObservableCollection<Task> Tasks { get; set; }

        private Command _addTaskCommand;
        public Command AddTaskCommand
        {
            get
            {
                return _addTaskCommand ?? (_addTaskCommand = new Command(obj => 
                {
                    string description = obj as string;
                    Tasks.Add(new Task(Tasks.Count, description)); 
                }));
            }
        }

        private Command _toggleCompletedCommand;
        public Command ToggleCompletedCommand
        {
            get
            {
                return _toggleCompletedCommand ?? (_toggleCompletedCommand = new Command(obj =>
                {
                    Task selectedTask = obj as Task;
                    selectedTask.ToggleCompletedState();
                }));
            }
        }

        private Command _deleteTaskCommand;
        public Command DeleteTaskCommand
        {
            get
            {
                return _deleteTaskCommand ?? (_deleteTaskCommand = new Command(obj =>
                {
                    Task selectedTask = obj as Task;
                    Tasks.Remove(selectedTask);
                }));
            }
        }

        public TaskViewModel()
        {
            Tasks = new ObservableCollection<Task>();
        }
    }
}
