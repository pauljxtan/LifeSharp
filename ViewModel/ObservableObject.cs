﻿using System.ComponentModel;

namespace LifeSharp.ViewModel
{
    /// <summary>
    /// A base for all ViewModel classes that is able to update the View of property changes.
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// The handler for the PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}