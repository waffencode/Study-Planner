using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Study_Planner.Components
{
    /// <summary>
    /// Описывает объект задачи и логику взаимодействия с ним.
    /// </summary>
    public class Task : INotifyPropertyChanged
    {
        private int _id;
        private string _shortDescription;
        private bool _isCompleted;

        public event PropertyChangedEventHandler PropertyChanged;
        
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Содержит идентификатор задачи.
        /// </summary>
        public int Id 
        { 
            get
            {
                return _id;
            } 
            set
            {
                _id = value;
            } 
        }
        /// <summary>
        /// Содержит краткое описание задачи.
        /// </summary>
        public string ShortDescription 
        { 
            get 
            {
                return _shortDescription;
            } 
            set 
            {
                _shortDescription = value;
            } 
        }
        /// <summary>
        /// Содержит статус выполнения задачи.
        /// </summary>
        public bool IsCompleted 
        {
            get 
            {
                return _isCompleted;
            }
            set { 
                _isCompleted = value;
                NotifyPropertyChanged();
            } 
        }

        /// <summary>
        /// Действие при добавлении задачи.
        /// </summary>
        /// <param name="givenID">Идентификатор задачи.</param>
        /// <param name="givenDescription">Краткое описание задачи.</param>
        public Task(int givenID, string givenDescription)
        {
            Id = givenID;
            ShortDescription = givenDescription;
            IsCompleted = false;
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
            IsCompleted = !IsCompleted;
        }
    }
}
