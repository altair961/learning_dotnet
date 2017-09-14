using System.ComponentModel;

namespace Core.Common
{
    public class ObjectBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool isDirty;
        public bool IsDirty
        {
            get { return isDirty; }
        }
    }
}
