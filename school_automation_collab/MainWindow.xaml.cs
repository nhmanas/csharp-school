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
using static School_Automation_Collab.sql.Database;

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
            //MessageBox.Show("Waiting for db Bedirhan hurry");
            School_Automation_Collab.sql.Database connection = new School_Automation_Collab.sql.Database();



            var check=connection.select("access", "userid,pass", $"userid='{idBox.Text}' and pass='{pwBox.Password}'");
            if (check.Count == 0)
            {
                MessageBox.Show("Incorrect username or password");
            }
            else if (check.Count > 1)
            {
                MessageBox.Show("There are multiple entries in the db");
            }
            else
            {
                MessageBox.Show("Welcome");
            }
        }


    }
}
