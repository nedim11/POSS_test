using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Model
{
    public class Categories : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public String Printer { get; set; }
        public String Name { get; set; }
        public Boolean Deleted { get; set; }
        public int Storage_Id { get; set; }
        public virtual ICollection<SubCategories> SubCategoriesLst { get; set; }

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
