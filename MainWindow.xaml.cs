using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;

namespace Contact_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=KZNNOTE051;Initial Catalog=Contact_System;Integrated Security=True;Encrypt=False;");

        public void load_Contacts()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select FirstName, LastName, DateOfBirth, CellNumber, Email,ct.Name Category, c.Active from Contact c, Category ct where c.CategoryID = ct.ID;", conn);

                DataTable dt = new DataTable();

                conn.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                dt.Load(rdr);
                conn.Close();
                dgContacts.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {

            }
        }

        private void btnDeleteContact_Click(object sender, RoutedEventArgs e)
        {

            if (dgContacts.SelectedItem != null)
            {

                // Get the selected items from the DataGrid
                var selectedItems = dgContacts.SelectedItems;


                // Iterate through each selected item and cast it to your data item type
                foreach (var selectedItem in selectedItems)
                {
                    // Cast the selected item to DataRowView
                    DataRowView rowView = (DataRowView)selectedItem;

                    // Access the data using the column name or index
                    string name = rowView["FirstName"].ToString(); // Replace "Name" with your actual column name
                    string lastname = rowView["LastName"].ToString(); // Replace "Email" with your actual column name
                    string CellNumber = rowView["CellNumber"].ToString();

                    if (name != null || lastname != null)
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT id FROM Contact WHERE FirstName = @FirstName AND LastName = @LastName and CellNumber = @CellNumber;", conn);
                        cmd.Parameters.AddWithValue("@FirstName", name);
                        cmd.Parameters.AddWithValue("@LastName", lastname);
                        cmd.Parameters.AddWithValue("@CellNumber", CellNumber);

                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            rdr.Close();

                            SqlCommand cmdDelete = new SqlCommand("Delete FROM Contact WHERE FirstName = @FirstName AND LastName = @LastName and CellNumber = @CellNumber;", conn);
                            cmdDelete.Parameters.AddWithValue("@FirstName", name);
                            cmdDelete.Parameters.AddWithValue("@LastName", lastname);
                            cmdDelete.Parameters.AddWithValue("@CellNumber", CellNumber);
                            try
                            {
                                cmdDelete.ExecuteNonQuery();
                                MessageBox.Show(name + " " + lastname + " has been deleted.");
                                conn.Close();
                                load_Contacts();
                                break;
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show("An unexpected error occurred." + ex.Message);
                            }

                            conn.Close();
                        }
                    }

                }
            }

        }

        private void btnAddContact_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Close App Notice",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                //Creates a delay of 1.4 seconds
                int delay = 1400;
                //---------CODE ATTRIBUTION---------
                //The following method was tafrom StackOverFlow
                //Author : Carlos Loth
                //Link: https://stackoverflow.com/questions/2902327/c-sharp-winforms-change-cursor-icon-of-mouse
                Mouse.OverrideCursor = Cursors.Wait;
                //---------END---------
                Task.Delay(delay).Wait();
                Environment.Exit(1);
            }
        }

        private void btnLoadAllContacts_Click(object sender, RoutedEventArgs e)
        {
            load_Contacts();
        }

        private void btnAddContacts_Click(object sender, RoutedEventArgs e)
        {
            Add_Contact add_Contact = new Add_Contact();
            add_Contact.Show();
            this.Hide();
        }

        private void btnDeleteContacts_Click(object sender, RoutedEventArgs e)
        {
            
            if (dgContacts.SelectedItem != null)
            {

                // Get the selected items from the DataGrid
                var selectedItems = dgContacts.SelectedItems;


                // Iterate through each selected item and cast it to your data item type
                foreach (var selectedItem in selectedItems)
                {
                    // Cast the selected item to DataRowView
                    DataRowView rowView = (DataRowView)selectedItem;

                    // Access the data using the column name or index
                    string name = rowView["FirstName"].ToString(); // Replace "Name" with your actual column name
                    string lastname = rowView["LastName"].ToString(); // Replace "Email" with your actual column name
                    string CellNumber = rowView["CellNumber"].ToString();

                    if (name != null || lastname != null)
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT id FROM Contact WHERE FirstName = @FirstName AND LastName = @LastName and CellNumber = @CellNumber;", conn);
                        cmd.Parameters.AddWithValue("@FirstName", name);
                        cmd.Parameters.AddWithValue("@LastName", lastname);
                        cmd.Parameters.AddWithValue("@CellNumber", CellNumber);

                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            rdr.Close();

                            SqlCommand cmdDelete = new SqlCommand("Delete FROM Contact WHERE FirstName = @FirstName AND LastName = @LastName and CellNumber = @CellNumber;", conn);
                            cmdDelete.Parameters.AddWithValue("@FirstName", name);
                            cmdDelete.Parameters.AddWithValue("@LastName", lastname);
                            cmdDelete.Parameters.AddWithValue("@CellNumber", CellNumber);
                            try
                            {
                                cmdDelete.ExecuteNonQuery();
                                MessageBox.Show(name + " " + lastname + " has been deleted.");
                                conn.Close();
                                load_Contacts();
                                break;
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show("An unexpected error occurred." + ex.Message);
                            }

                            conn.Close();
                        }
                    }

                }
            }

        }
    }
}
