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

namespace School_Automation_Collab
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            // May create another window for alerts, messagebox is ugly

            if (idBox.Text=="")
            {
                MessageBox.Show("Fill ID Number!");
                return;
            }
            if (pwBox.Password == "")
            {
                MessageBox.Show("Fill Password!");
                return;
            }
            MessageBox.Show("Waiting for db Bedirhan hurry");
        }


    }
}
