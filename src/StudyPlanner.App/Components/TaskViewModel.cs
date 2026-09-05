using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using StudyTask = StudyPlanner.Domain.Entities.StudyTask;

namespace StudyPlanner.App.Components;

/// <summary>
/// Главная модель представления списка задач. Управляет коллекцией <see cref="TaskItemViewModel"/>,
/// командой добавления задач, а также загрузкой и сохранением.
/// Per-item команды (Toggle/Edit/Save/Delete) живут на <see cref="TaskItemViewModel"/>; здесь — только общие.
/// </summary>
public partial class TaskViewModel : ObservableObject
{
    private readonly string _tasksFilePath = "SavedTasks.json";

    public string GreetingText
    {
        get
        {
            var time = TimeOnly.FromDateTime(DateTime.Now);
            var timeOfDayGreeting = time switch
            {
                _ when time <= new TimeOnly(6, 0, 0) => "Good night",
                _ when time <= new TimeOnly(10, 0, 0) => "Good morning",
                _ when time <= new TimeOnly(17, 0, 0) => "Good afternoon",
                _ when time <= new TimeOnly(20, 0, 0) => "Good evening",
                _ => "Good day",
            };
            return $"{timeOfDayGreeting}! You have {Tasks.Count(task => !task.Entity.IsCompleted)} tasks to do today.";
        }
    }

    /// <summary>
    /// Коллекция биндинг-обёрток задач, отображаемая в UI.
    /// </summary>
    [ObservableProperty]
    public partial ObservableCollection<TaskItemViewModel> Tasks { get; set; } = [];

    /// <summary>
    /// Добавляет новую задачу с указанным описанием.
    /// </summary>
    /// <param name="description">Текст описания задачи.</param>
    [RelayCommand]
    private void AddTask(string description)
    {
        Tasks.Add(new TaskItemViewModel(this) { ShortDescription = description });
        OnPropertyChanged(nameof(GreetingText));
    }

    /// <summary>
    /// Асинхронная команда инициализации: загружает сохранённые задачи при отображении окна (по событию <c>Loaded</c>).
    /// </summary>
    [RelayCommand]
    private async Task InitializeAsync()
    {
        await foreach (var task in await FileManager.LoadCollectionFromFile<StudyTask>(_tasksFilePath))
        {
            if (task is not null)
            {
                Tasks.Add(new TaskItemViewModel(this) { ShortDescription = task.ShortDescription, IsCompleted = task.IsCompleted });
            }
        }

        OnPropertyChanged(nameof(GreetingText));
    }

    /// <summary>
    /// Распаковывает отображаемые задачи в доменные сущности и сохраняет их в файл.
    /// </summary>
    public async Task SaveTasksAsync()
    {
        await FileManager.SaveCollectionToFile([.. Tasks.Select(task => task.Entity)], _tasksFilePath);
    }
}
