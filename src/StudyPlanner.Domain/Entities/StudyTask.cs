namespace StudyPlanner.Domain.Entities;

/// <summary>
/// Чистая доменная сущность учебной задачи.
/// </summary>
public class StudyTask
{
    /// <summary>
    /// Краткое описание задачи.
    /// </summary>
    public string ShortDescription { get; set; }

    /// <summary>
    /// Признак выполнения задачи.
    /// </summary>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// Признак активного режима редактирования описания.
    /// </summary>
    public bool IsEditModeEnabled { get; set; }

    /// <summary>
    /// Создаёт задачу с указанным описанием.
    /// </summary>
    /// <param name="shortDescription">Текст описания задачи.</param>
    public StudyTask(string shortDescription) => ShortDescription = shortDescription;

    /// <summary>
    /// Переключает состояние выполнения на противоположное.
    /// </summary>
    public void ToggleCompletedState() => IsCompleted = !IsCompleted;

    /// <summary>
    /// Переключает режим редактирования на противоположное состояние.
    /// </summary>
    public void ToggleEditState() => IsEditModeEnabled = !IsEditModeEnabled;
}
