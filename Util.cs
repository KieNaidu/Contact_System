using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace Contact_System
{
    public class Util
    {
        public static SqlConnection conn = new SqlConnection("Data Source=KZNNOTE051;Initial Catalog=Contact_System;Integrated Security=True;Encrypt=False;");

        public static List<string> loadCategories()
        {
            SqlCommand cmd = new SqlCommand("select name from Category", conn);
            List<string> categories = new List<string>();
            try
            {
                Util.conn.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    string categoryName = rdr["name"].ToString();
                    categories.Add(categoryName);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred." + ex.Message);

            }
            conn.Close();
            return categories;

        }
        public static int getCategoryID(string category)
        {
            int categoryId = -1; // Default value if category is not found
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select id from Category where name = @name", conn);

                cmd.Parameters.AddWithValue("@name", category);

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    categoryId = rdr.GetInt32(0); // Assuming the ID is stored in the first column (index 0)
                    conn.Close();
                    return categoryId;

                }

                rdr.Close(); // Close the SqlDataReader
                conn.Close();
                return categoryId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred." + ex.Message);
                conn.Close();
                return categoryId;
            }
        }

        public static void addContact(Contact newcontact)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into contact (CategoryID, FirstName, LastName, DateOfBirth, CellNumber, Email, DateCreated, Active) values (@CategoryID, @FirstName, @LastName, @DateOfBirth, @CellNumber, @Email, @DateCreated, @Active)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("CategoryID", newcontact.CategoryID);
                cmd.Parameters.AddWithValue("FirstName", newcontact.FirstName);
                cmd.Parameters.AddWithValue("LastName", newcontact.LastName);
                cmd.Parameters.AddWithValue("DateOfBirth", newcontact.DateOfBirth);
                cmd.Parameters.AddWithValue("CellNumber", newcontact.CellNumber);
                cmd.Parameters.AddWithValue("Email", newcontact.Email);

                cmd.Parameters.AddWithValue("DateCreated", newcontact.DateCreated);
                cmd.Parameters.AddWithValue("Active", newcontact.Active);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Contact added");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred." + ex.Message);
                conn.Close();
            }
        }
    }
}
