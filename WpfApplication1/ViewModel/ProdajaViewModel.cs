using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Input;


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
