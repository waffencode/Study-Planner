using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Planner.Components
{
    /// <summary>
    /// Описывает объект задачи и логику взаимодействия с ним.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Содержит идентификатор задачи
        /// </summary>
        private int id;
        /// <summary>
        /// Содержит краткое описание задачи.
        /// </summary>
        private string shortDescription;
        /// <summary>
        /// Содержит статус выполнения задачи.
        /// </summary>
        private bool isCompleted;

        /// <summary>
        /// Действие при добавлении задачи.
        /// </summary>
        /// <param name="givenID">Идентификатор задачи.</param>
        /// <param name="givenDescription">Краткое описание задачи.</param>
        public Task(int givenID, string givenDescription)
        {
            id = givenID;
            shortDescription = givenDescription;
            isCompleted = false;
        }

        /// <summary>
        /// Действие при удалении задачи.
        /// </summary>
        ~Task()
        {
            // ...
        }

        /// <summary>
        /// Меняет статус завершённости задачи.
        /// </summary>
        public void ToggleCompletedState()
        {
            isCompleted = !isCompleted;
        }
    }
}
