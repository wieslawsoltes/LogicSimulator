using System;
using System.ComponentModel;

namespace Logic.Model.Core
{
    public abstract class LogicObject : INotifyPropertyChanged
    {
        public void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Guid id = Guid.Empty;
        private string name = string.Empty;

        public Guid Id
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    Notify("Id");
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    Notify("Name");
                }
            }
        }

        private double x;
        private double y;
        private double z;

        public double X
        {
            get { return x; }
            set
            {
                if (value != x)
                {
                    x = value;
                    Notify("X");
                }
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                if (value != y)
                {
                    y = value;
                    Notify("Y");
                }
            }
        }

        public double Z
        {
            get { return z; }
            set
            {
                if (value != z)
                {
                    z = value;
                    Notify("Z");
                }
            }
        }
    }
}
