using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudyTask = StudyPlanner.Domain.Entities.StudyTask;

namespace StudyPlanner.App.Components;

/// <summary>
/// Биндинг-обёртка задачи для UI: чистая observable-модель на CommunityToolkit.Mvvm.
/// Хранит собственное состояние (не делегирует доменной сущности); проекция в <see cref="StudyTask"/>
/// выполняется через <see cref="Entity"/> на границе сохранения.
/// </summary>
/// <remarks>
/// Создаёт элемент со ссылкой на родительскую модель представления (для команды удаления).
/// </remarks>
/// <param name="owner">Родительская модель представления.</param>
public partial class TaskItemViewModel(TaskViewModel owner) : ObservableObject
{
    private readonly TaskViewModel _owner = owner;

    /// <summary>
    /// Описание задачи.
    /// </summary>
    [ObservableProperty]
    private string _shortDescription = string.Empty;

    /// <summary>
    /// Признак выполнения задачи; уведомляет также производные свойства видимости.
    /// </summary>
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsToggleCompletedVisible))]
    [NotifyPropertyChangedFor(nameof(IsUndoneVisible))]
    private bool _isCompleted;

    /// <summary>
    /// Признак активного режима редактирования; уведомляет также производные свойства видимости.
    /// </summary>
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsDisplayMode))]
    [NotifyPropertyChangedFor(nameof(IsToggleCompletedVisible))]
    [NotifyPropertyChangedFor(nameof(IsUndoneVisible))]
    private bool _isEditModeEnabled;

    /// <summary>
    /// Режим отображения (не редактирование) — управляет видимостью кнопки Edit и подписи.
    /// </summary>
    public bool IsDisplayMode => !IsEditModeEnabled;

    /// <summary>
    /// Видимость кнопки "Done" — только в режиме отображения для невыполненной задачи.
    /// </summary>
    public bool IsToggleCompletedVisible => !IsCompleted && !IsEditModeEnabled;

    /// <summary>
    /// Видимость кнопки "Undone" — только в режиме редактирования выполненной задачи.
    /// </summary>
    public bool IsUndoneVisible => IsCompleted && IsEditModeEnabled;

    /// <summary>
    /// Проекция текущего состояния в доменную сущность для сохранения.
    /// </summary>
    /// <remarks>Режим редактирования не сохраняется (он является transient UI-состоянием).</remarks>
    public StudyTask Entity => new(ShortDescription) { IsCompleted = IsCompleted };

    /// <summary>
    /// Переключает состояние выполнения задачи.
    /// </summary>
    [RelayCommand]
    private void ToggleCompleted() => IsCompleted = !IsCompleted;

    /// <summary>
    /// Переключает режим редактирования описания.
    /// </summary>
    [RelayCommand]
    private void Edit() => IsEditModeEnabled = !IsEditModeEnabled;

    /// <summary>
    /// Сохраняет отредактированный текст описания и выходит из режима редактирования.
    /// </summary>
    /// <param name="newText">Новый текст описания.</param>
    [RelayCommand]
    private void Save(string newText)
    {
        ShortDescription = newText;
        IsEditModeEnabled = false;
    }

    /// <summary>
    /// Удаляет задачу из родительской коллекции.
    /// </summary>
    [RelayCommand]
    private void Delete() => _owner.Tasks.Remove(this);
}
