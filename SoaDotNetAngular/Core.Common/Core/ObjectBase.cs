using Core.Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Core.Common.Core
{
    public class ObjectBase : INotifyPropertyChanged
    {
        private event PropertyChangedEventHandler propertyChanged;

        List<PropertyChangedEventHandler> propertyChangedSubsribers =
            new List<PropertyChangedEventHandler>();

        private bool isDirty;
        public bool IsDirty
        {
            get { return isDirty; }
            private set { isDirty = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                if(!propertyChangedSubsribers.Contains(value))
                {
                    propertyChanged += value;
                    propertyChangedSubsribers.Add(value);
                }
            }
            remove
            {
                propertyChanged -= value;
                propertyChangedSubsribers.Remove(value);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName, bool makeDirty)
        {
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));

            if (makeDirty)
                IsDirty = true;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName, true);
        }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            string propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            OnPropertyChanged(propertyName);
        }
    }
}
