using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace Study_Planner.Components
{
    public static class FileManager
    {
        public static void SaveCollectionToFile<T>(ObservableCollection<T> Collection, string filePath)
        {
            StreamWriter JsonFileStream = new(filePath);

            foreach (T element in Collection)
            {
                JsonFileStream.WriteLine(JsonSerializer.Serialize(element));
            }

            JsonFileStream.Close();
        }

        public static void LoadCollectionFromFile<T>(ObservableCollection<T> Collection, string filePath)
        {
            StreamReader JsonFileStream = new(filePath);

            while (!JsonFileStream.EndOfStream)
            {
                Collection.Add(JsonSerializer.Deserialize<T>(JsonFileStream.ReadLine()));
            }

            JsonFileStream.Close();
        }
    }
}