using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Models
{
    [Serializable]
    public class ModelBase : INotifyDataErrorInfo, INotifyPropertyChanged
    {
        public List<string> propertyErrors { get; set; }

        #region INotifyDataErrorInfo Members

        public Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        [field: NonSerialized]
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (!String.IsNullOrEmpty(propertyName))
                if (errors.ContainsKey(propertyName))
                    return errors[propertyName];

            return new string[0];
        }

        public void AddErrorForProperty(string propertyName, string errorMessage)
        {
            bool oldHasErrors = HasErrors;
            if (!errors.ContainsKey(propertyName)) { errors.Add(propertyName, new List<string>()); }

            propertyErrors = errors[propertyName];
            if (propertyErrors.Count == 0)
            {
                propertyErrors.Add(errorMessage);
                RaiseErrorsChanged(propertyName);
            }

            if (oldHasErrors != HasErrors) { OnHasErrorsChanged(); }
        }

        public void RemoveError(string propertyName)
        {
            if (errors.ContainsKey(propertyName))
            {
                propertyErrors.Remove(propertyName);
                errors.Remove(propertyName);
            }

            RaiseErrorsChanged(propertyName);
        }

        public void RemoveErrorAll()
        {
            if (errors != null && errors.Count > 0)
            {
                List<string> listErrorKeys = new List<string>(errors.Keys);

                foreach (var key in listErrorKeys)
                    RemoveError(key);

            }
        }

        protected virtual void OnHasErrorsChanged()
        {
            RaisePropertyChanged("HasErrors");
        }

        private void RaiseErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public bool HasErrors
        {
            get { return errors.Count > 0; }
        }

        #endregion INotifyDataErrorInfo Members

        #region INotifyPropertyChanged Members

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        #endregion INotifyPropertyChanged Members

        #region Clone Methods

        /// <summary>
        /// For Shallow Clone, It's copy only primitive type.
        /// </summary>
        /// <returns>Current type of object</returns>
        public ModelBase Clone()
        {
            return MemberwiseClone() as ModelBase;
        }

        /// <summary>
        /// For Deep Clone, It's allocate another memory space.
        /// Before using must the class as Serializable.
        /// </summary>
        /// <returns>Current type of object</returns>
        public ModelBase DeepClone()
        {
            object objResult;

            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, this);

                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }

            return objResult as ModelBase;
        }

        #endregion Clone Methods
    }
}
