using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Contact_System
{
    /// <summary>
    /// Interaction logic for Update_Contact.xaml
    /// </summary>
    public partial class Update_Contact : Window
    {
        public Update_Contact()
        {
            InitializeComponent();

        }
        SqlConnection conn = new SqlConnection("Data Source=KZNNOTE051;Initial Catalog=Contact_System;Integrated Security=True;Encrypt=False;");

        private void btnEditContact_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddContacts_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
