using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Study_Planner.Components
{
    public class Task : INotifyPropertyChanged
    {
        private string _shortDescription;
        public string ShortDescription { get => _shortDescription; set { _shortDescription = value; NotifyPropertyChanged(); } }

        private bool _isCompleted = false;
        public bool IsCompleted { get => _isCompleted; set { _isCompleted = value; NotifyPropertyChanged(); } }

        private bool _isEditModeEnabled = false;
        public bool IsEditModeEnabled { get => _isEditModeEnabled; set { _isEditModeEnabled = value; NotifyPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [JsonConstructor]
        public Task(string shortDescription) => ShortDescription = shortDescription;

        public void ToggleCompletedState() => IsCompleted = !IsCompleted;

        public void ToggleEditState() => IsEditModeEnabled = !IsEditModeEnabled;
    }
}