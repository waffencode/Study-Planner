using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace Study_Planner.Components
{
    public static class FileManager
    {
        public static void SaveCollectionToFile<T>(ObservableCollection<T> Collection, string filePath)
        {
            StreamWriter JsonFileStream = (File.Exists(filePath)) ? new(filePath) : new(File.Create(filePath));

            foreach (T element in Collection)
            {
                JsonFileStream.WriteLine(JsonSerializer.Serialize(element));
            }

            JsonFileStream.Close();
        }

        public static void LoadCollectionFromFile<T>(ObservableCollection<T> Collection, string filePath)
        {
            StreamReader JsonFileStream = (File.Exists(filePath)) ? new(filePath) : new(File.Create(filePath));

            while (!JsonFileStream.EndOfStream)
            {
                Collection.Add(JsonSerializer.Deserialize<T>(JsonFileStream.ReadLine()));
            }

            JsonFileStream.Close();
        }
    }
}