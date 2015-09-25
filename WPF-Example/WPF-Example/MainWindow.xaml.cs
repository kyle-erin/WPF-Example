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

namespace WPF_Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Displays if the user selected 'Male'
        private static string MALE_VAL = "Male";

        // Displays if the user selected 'Female'
        private static string FEMALE_VAL = "Female";

        // When a user doesn't select a gender
        private static string GENDER_EMPTY = "N/A";

        // Limit middle intial to one character
        private static int MIDDLE_MAX_LENGTH = 1;

        // Limit first and last names to avoid overflow issues
        private static int NAME_MAX_LENGTH = 25;

        public MainWindow()
        {
            InitializeComponent();

            // Set max length of text boxes
            middle.MaxLength = MIDDLE_MAX_LENGTH;
            first.MaxLength = NAME_MAX_LENGTH;
            last.MaxLength = NAME_MAX_LENGTH;

            // Fetch saved info
            UserInfo info = Storage.Instance.readInfo();
            if(info != null)
            {
                first.Text = info.mFirst;
                middle.Text = info.mMI;
                last.Text = info.mLast;
                email.Text = info.mEmail;
                if(info.mGender.CompareTo(MALE_VAL) == 0)
                {
                    rMale.IsChecked = true;
                }
                else if (info.mGender.CompareTo(FEMALE_VAL) == 0)
                {
                    rFemale.IsChecked = true;
                }
            }
            Console.WriteLine("OWEIFJ");
        }

        // Handles on save event
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Display save comfirm dialog
            SaveWindow window = new SaveWindow(first.Text, middle.Text, last.Text, email.Text, getGender() );
            window.Show();
        }

        // Handles displaying the user information in another window
        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            // Display saved content
            DisplayWindow window = new DisplayWindow(first.Text + " " + middle.Text + ". " + last.Text, email.Text, getGender() );
            window.Show();
        }

        // Returns what gender the user selected
        private string getGender()
        {
            return rMale.IsChecked.Value ? MALE_VAL : rFemale.IsChecked.Value ? FEMALE_VAL : GENDER_EMPTY;
        }
    }
}
