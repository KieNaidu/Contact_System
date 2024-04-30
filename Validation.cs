using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Contact_System
{
    public class Validation
    {
        //Validation method to check if there is something in the string
        public static bool checkStringInput(string example)
        {

            bool isString = example.Length > 0;


            return isString;
        }
        //Validation method to check if a string only has numbers
        public static bool checkNumberOnly(string example)
        {
            bool isNumber;
            Regex newReg = new Regex("[0-9]");
            isNumber = newReg.IsMatch(example);
            return isNumber;
        }
        //Validation method to check if a string has numbers and other characters
        public static bool isNumber(string example)
        {
            bool isNumber;
            Regex newReg = new Regex("^[0-9]*$");
            isNumber = newReg.IsMatch(example);
            return isNumber;
        }
        //Validation method to check if a string has any special characters in it
        public static bool checkSpecial(string example)
        {
            Regex newReg = new Regex("[^A-Za-z0-9 ]");
            bool isSpecial = newReg.IsMatch(example);

            return isSpecial;
        }
    }
}
