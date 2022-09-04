using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Study_Planner.Components
{
    /// <summary>
    /// Описывает логику взаимодействия со всеми задачами в совокупности и отображение их в интерфейсе пользователя.
    /// </summary>
    public class TasksCollection
    {
        const int MAX_TASKS = 10;
        /// <summary>
        /// Содержит все добавленные задачи.
        /// </summary>
        public List<Task> tasksList = new List<Task>(MAX_TASKS);

        /// <summary>
        /// Создаёт новую задачу.
        /// </summary>
        /// <param name="shortDescription">Краткое описание создаваемой задачи.</param>
        public void CreateTask(string shortDescription)
        {
            int newTaskID = GetTasksCount();

            Task newTask = new Task(newTaskID, shortDescription);

            try
            {
                tasksList.Add(newTask);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException("Too much tasks.", e);
            }
        }

        /// <summary>
        /// Получает число задач, добавленных пользователем.
        /// </summary>
        /// <returns>Целое число — количество значений типа <seealso cref="Task" /> в списке <paramref name="tasksList" />.</returns>
        public int GetTasksCount()
        {
            return tasksList.Count();
        }
    }
}
