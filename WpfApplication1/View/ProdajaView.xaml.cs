using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication1.ViewModel;

namespace WpfApplication1.View
{
    /// <summary>
    /// Interaction logic for ProdajaView.xaml
    /// </summary>
    public partial class ProdajaView : Page
    {
        public ProdajaView()
        {
            InitializeComponent();

            //this.DataContext = new ProdajaViewModel();
          
        }


    }
}
