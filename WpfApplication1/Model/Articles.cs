using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace WpfApplication1.Model
{
    public class Articles : INotifyPropertyChanged
    {

        public int Id { get; set; }
        public Boolean Deleted { get; set; }
        public byte[] Image { get; set; }
        public String Name { get; set; }
        public Boolean Tag { get; set; }
        public String ArticleNumber { get; set; }
        public int Order { get; set; }
        public Double Price { get; set; }
        public int SubCategory_Id { get; set; }
        public String BarCode { get; set; }
        public String Code { get; set; }
        public float ReturnFee { get; set; }
        public int FreeModifiers { get; set; }
        public virtual ICollection<Operators> OperatorsLst { get; set; }

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
