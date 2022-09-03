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
        const int MAX_TASKS = 5;
        /// <summary>
        /// Содержит все добавленные задачи.
        /// </summary>
        public Task[] tasksArray = new Task[MAX_TASKS];

        /// <summary>
        /// Создаёт новую задачу.
        /// </summary>
        public void Debug_CreateTask(string shortDescription)
        {
            int newTaskID = GetTasksCount();

            Task newTask = new Task(newTaskID, shortDescription);

            try
            {
                tasksArray[newTaskID] = newTask;
            }
            catch (IndexOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException("Too much tasks.", e);
            }
        }

        /// <summary>
        /// Получает число задач, добавленных пользователем.
        /// </summary>
        /// <returns>Целое число — количество значений типа <seealso cref="Task" /> в массиве <paramref name="tasksArray" />.</returns>
        public int GetTasksCount()
        {
            int count = 0;

            for (int i = 0; i < MAX_TASKS; i++)
            {
                if (tasksArray[i] is Task)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
