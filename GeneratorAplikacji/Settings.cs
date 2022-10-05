using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorAplikacji
{
    public class Setting
    {
        private string _name;
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {

                    throw new ApplicationException("Property [Name] in class [Setting] is null or empty");
                }
                return _name;
            }
            set { _name = value; }
        }
    }
    [Serializable]
    public class Setting<T> : Setting
    {
        private T _value;
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        public Type Type
        {
            get
            {
                return typeof(T);
            }
        }
        public Setting()
        {
        }
    }
}
