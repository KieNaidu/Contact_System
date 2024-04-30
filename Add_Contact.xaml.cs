using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Windows;

namespace Contact_System
{
    /// <summary>
    /// Interaction logic for Add_Contact.xaml
    /// </summary>
    public partial class Add_Contact : Window
    {
        public Add_Contact()
        {
            InitializeComponent();
            load_categories();
        }

        //Method to set all categories in the combo box
        private void load_categories()
        {
            List<string> categories = Util.loadCategories();
            foreach (string category in categories)
            {
                cmbCategoryType.Items.Add(category);
            }
        }

        private void add_contact()
        {

            //Validating all fields before inserting
            if (Validation.checkStringInput(txtFirstName.Text) && Validation.checkStringInput(txtLastName.Text) && Validation.checkStringInput(txtCellphone.Text)
                && Validation.checkStringInput(txtEmail.Text) && Validation.isNumber(txtCellphone.Text) && Validation.checkStringInput(cmbCategoryType.SelectedItem.ToString()))
            {
                //creating object and setting data params
                Contact contact = new Contact();
                int category = Util.getCategoryID(cmbCategoryType.SelectedItem.ToString());

                contact.FirstName = txtFirstName.Text;
                contact.LastName = txtLastName.Text;
                contact.CellNumber = txtCellphone.Text;
                contact.Email = txtEmail.Text;
                contact.CategoryID = category;
                contact.DateCreated = DateTime.Now;
                contact.Image = null;
                DateTime? selectedDate = dtpDateOfBirth.SelectedDate;
                contact.DateOfBirth = selectedDate;
                contact.Active = true;
                //calls method to add contact
                Util.addContact(contact);
                //if successful it will go back to main screen
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Contact information incorrect");
            }

        }

        private void btnAddContacts_Click(object sender, RoutedEventArgs e)
        {
            add_contact();

        }
    }
}
