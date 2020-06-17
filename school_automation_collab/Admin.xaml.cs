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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }
        public Admin(string title, string name,string surname,string id)
        {
            InitializeComponent();
            titleLabel.Content = title;
            nameLabel.Content = name;
            surnameLabel.Content = surname;
            idnumberLabel.Content = id;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void logout_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
