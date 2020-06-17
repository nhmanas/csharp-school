using School_Automation_Collab.sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
    /// Interaction logic for Teacher.xaml
    /// </summary>
    public partial class Teacher : Window
    {
        DataTable courseList = new DataTable();
        public Teacher()
        {
            InitializeComponent();
        }
        public Teacher(string name,string surname,string id)
        {
            InitializeComponent();
            nameLabel.Content = name;
            surnameLabel.Content = surname;
            idnumberLabel.Content = id;

            var query = "select * from courses where instructor_id=@id";
            var lstParams = new List<cmdParameterType> { new cmdParameterType("@id", id) };
            var check = Database.query(query, lstParams);
            if (check==null)
            {
                new WarningWindow().Show();
                this.Close();
            }
            courseList = check;
            foreach (DataRow item in courseList.Rows)
            {
                selectcourseCombo.Items.Add(item["name"].ToString());
            }

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            new WarningWindow(MainWindow.colorOK, "OK", "Logout successfull", new MainWindow());
            this.Close();
        }
    }
}
