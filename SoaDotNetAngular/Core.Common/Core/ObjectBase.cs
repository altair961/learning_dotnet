using Core.Common.Extensions;
using Core.Common.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Core.Common.Core
{
    public class ObjectBase : INotifyPropertyChanged
    {
        private event PropertyChangedEventHandler propertyChanged;

        List<PropertyChangedEventHandler> propertyChangedSubsribers =
            new List<PropertyChangedEventHandler>();

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

        private bool isDirty;
        public bool IsDirty
        {
            get { return isDirty; }
            set { isDirty = value; }
        }

        public List<ObjectBase> GetDirtyObjects()
        {
            List<ObjectBase> dirtyObjects = new List<ObjectBase>();

            WalkObjectGraph(
            o =>
            {
                if (o.IsDirty)
                    dirtyObjects.Add(o);

                return false;
            }, coll => { });

            return dirtyObjects;
        }

        public void CleanAll()
        {
            WalkObjectGraph(
            o =>
            {
                if (o.IsDirty)
                    o.IsDirty = false;
                return false;
            }, coll => { });
        }

        public virtual bool IsAnythingDirty()
        {
            bool IsDirty = false;

            WalkObjectGraph(
            o =>
            {
                if (o.IsDirty)
                {
                    isDirty = true;
                    return true;
                }
                else
                    return false;
            }, coll => { });

            return isDirty;
        }

        protected void WalkObjectGraph(Func<ObjectBase, bool> snippetForObject,
                                       Action<IList> snippetForCollection,
                                       params string[] exemptProperties)
        {
            List<ObjectBase> visited = new List<ObjectBase>();
            Action<ObjectBase> walk = null;

            List<string> exemptions = new List<string>();

            if (exemptProperties != null)
                exemptions = exemptProperties.ToList();

            walk = (o) =>
            {
                if (o != null && !visited.Contains(o))
                {
                    visited.Add(o);

                    bool exitWalk = snippetForObject.Invoke(o);
                    if (!exitWalk)
                    {
                        PropertyInfo[] properties = o.GetBrowsableProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            if (!exemptions.Contains(property.Name))
                            {
                                if (property.PropertyType.IsSubclassOf(typeof(ObjectBase)))
                                {
                                    ObjectBase obj = (ObjectBase)property.GetValue(o, null);
                                    walk(obj);
                                }
                                else
                                {
                                    IList coll = property.GetValue(o, null) as IList;
                                    if (coll != null)
                                    {
                                        snippetForCollection.Invoke(coll);
                                        foreach (object item in coll)
                                        {
                                            if (item is ObjectBase)
                                                walk((ObjectBase)item);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
