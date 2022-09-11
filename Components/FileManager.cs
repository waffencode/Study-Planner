using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Text.Json.Nodes;

namespace Study_Planner.Components
{
    public class FileManager
    {
        public void SaveTasksToFile(ObservableCollection<Task> Tasks)
        {
            string path = "SavedTasks.json";
            StreamWriter JsonFileStream = new StreamWriter(path);

            foreach (Task task in Tasks)
            {
                JsonFileStream.WriteLine(JsonSerializer.Serialize<Task>(task));
            }

            JsonFileStream.Close();
        }

        public ObservableCollection<Task> LoadTasksFromFile()
        {
            ObservableCollection<Task> Tasks = new ObservableCollection<Task>();
            string path = "SavedTasks.json";
            StreamReader JsonFileStream = new StreamReader(path);
            string jsonTask;

            while ((jsonTask = JsonFileStream.ReadLine()) != null)
            {
                Task task = (Task)JsonSerializer.Deserialize<Task>(jsonTask);
                Tasks.Add(task);
            }

            JsonFileStream.Close();

            return Tasks;
        }
    }
}
