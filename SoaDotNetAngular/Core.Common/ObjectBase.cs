using System.Collections.Generic;
using System.ComponentModel;

namespace Core.Common
{
    public class ObjectBase : INotifyPropertyChanged
    {
        private event PropertyChangedEventHandler propertyChanged;

        List<PropertyChangedEventHandler> propertyChangedSubsribers =
            new List<PropertyChangedEventHandler>();

        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName, true);
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

        private bool isDirty;
        public bool IsDirty
        {
            get { return isDirty; }
            private set { isDirty = value; }
        }
    }
}
