using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Study_Planner.Components
{
    public class Task : INotifyPropertyChanged
    {
        private int _id;
        public int Id { get => _id; set => _id = value; }

        private string _shortDescription;
        public string ShortDescription { get => _shortDescription; set => _shortDescription = value; }

        private bool _isCompleted = false;
        public bool IsCompleted { get => _isCompleted; set { _isCompleted = value; NotifyPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Task(int givenID, string givenDescription)
        {
            Id = givenID;
            ShortDescription = givenDescription;
            IsCompleted = false;
        }

        public void ToggleCompletedState()
        {
            IsCompleted = !IsCompleted;
        }
    }
}