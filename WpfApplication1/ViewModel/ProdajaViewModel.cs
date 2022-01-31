using System.ComponentModel;
using System.Data;


namespace WpfApplication1.ViewModel
{
    public class ProdajaViewModel : INotifyPropertyChanged
    {
        private POSSectorDBContext dc = new POSSectorDBContext();


        public DataTable getAllOperatorsDG
        {
            get
            {
                return dc.PopulateDataGrid();
            }
        }

        public string getUkupno
        {
            get
            {
                return dc.PopulateLabel();
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }

}
