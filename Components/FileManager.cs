using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace Study_Planner.Components
{
    public class FileManager
    {
        private const string taskStorageFilePath = "SavedTasks.json";

        public void SaveTasksToFile(ObservableCollection<Task> Tasks)
        {
            StreamWriter JsonFileStream = new(taskStorageFilePath);

            foreach (Task task in Tasks)
            {
                JsonFileStream.WriteLine(JsonSerializer.Serialize(task));
            }

            JsonFileStream.Close();
        }

        public void LoadTasksFromFile(ObservableCollection<Task> Tasks)
        {
            StreamReader JsonFileStream = new(taskStorageFilePath);

            while (!JsonFileStream.EndOfStream)
            {
                Tasks.Add(JsonSerializer.Deserialize<Task>(JsonFileStream.ReadLine()));
            }

            JsonFileStream.Close();
        }
    }
}