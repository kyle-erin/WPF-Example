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
using System.Windows.Shapes;

namespace WPF_Example
{
    /// <summary>
    /// Interaction logic for SaveWindow.xaml
    /// </summary>
    public partial class SaveWindow : Window
    {
        // User information to save
        private UserInfo mInfo;

        public SaveWindow(string first, string mi, string last, string email, string gender)
        {
            InitializeComponent();
            mInfo = new UserInfo(first, mi, last, email, gender);
        }

        private void btnCancelClick(object sender, RoutedEventArgs e)
        {
            // Don't save, close
            this.Close();
        }

        private void btnConfirmClick(object sender, RoutedEventArgs e)
        {
            // Save data, close
            Storage.Instance.saveInfo(mInfo);
            this.Close();
        }
    }
}
