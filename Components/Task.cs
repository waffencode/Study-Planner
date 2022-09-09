using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Study_Planner.Components
{
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

        public bool IsCompleted 
        {
            get 
            {
                return _isCompleted;
            }
            set 
            { 
                _isCompleted = value;
                NotifyPropertyChanged();
            } 
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
