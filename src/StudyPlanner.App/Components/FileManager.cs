using System.IO;
using System.Text.Json;

namespace StudyPlanner.App.Components;

/// <summary>
/// Сохраняет и загружает коллекции доменных сущностей в текстовый файл построчно (каждый элемент — отдельная JSON-строка).
/// </summary>
public static class FileManager
{
    /// <summary>
    /// Записывает элементы коллекции в файл по одной JSON-строке на элемент (файл перезаписывается).
    /// </summary>
    /// <typeparam name="T">Тип сериализуемого элемента.</typeparam>
    /// <param name="collection">Сохраняемая коллекция.</param>
    /// <param name="filePath">Путь к файлу.</param>
    public static async Task SaveCollectionToFile<T>(List<T> collection, string filePath)
    {
        await using Stream jsonFileStream = new FileStream(filePath, FileMode.Create);
        await using StreamWriter writer = new(jsonFileStream);
        await writer.WriteAsync(JsonSerializer.Serialize(collection));
    }

    /// <summary>
    /// Читает файл и десериализует его содержимое как JSON-массив элементов.
    /// Если файл отсутствует — он создаётся пустым; при ошибке разбора возвращается пустая последовательность.
    /// Поток читается и закрывается внутри метода, поэтому возвращаемый <see cref="IAsyncEnumerable{T}"/> безопасно использовать после выхода из него.
    /// </summary>
    /// <typeparam name="T">Тип десериализуемого элемента.</typeparam>
    /// <param name="filePath">Путь к файлу.</param>
    /// <returns>Асинхронная последовательность загруженных элементов (возможно, с <c>null</c>-элементами).</returns>
    public static async Task<IAsyncEnumerable<T?>> LoadCollectionFromFile<T>(string filePath)
    {
        try
        {
            await using Stream jsonFileStream = new FileStream(filePath, FileMode.OpenOrCreate);
            List<T?> result = new();
            await foreach (T? item in JsonSerializer.DeserializeAsyncEnumerable<T>(jsonFileStream))
            {
                result.Add(item);
            }
            return result.ToAsyncEnumerable();
        }
        catch
        {
            return new List<T?>().ToAsyncEnumerable();
        }
    }
}
