using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WpfApplication1.Model
{
    public class Operators : INotifyPropertyChanged
    {
        public Operators()
        {
            ArticlesLst = new List<Articles>();
        }
        public int Id { get; set; }
        public String Name { get; set; }
        public virtual ICollection<Articles> ArticlesLst { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
