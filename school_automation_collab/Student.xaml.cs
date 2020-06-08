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

namespace School_Automation_Collab
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Student : Window
    {
        
        public Student()
        {
            

            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            WarningWindow ww = new WarningWindow(MainWindow.colorOK,"OK","Log out successfull");
            ww.Show();
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
