using School_Automation_Collab.sql;
using System;
using System.Collections.Generic;
using System.Data;
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
        string faculty;
        string department;
        public Student()
        {
            

            InitializeComponent();
        }
        public Student(string name,string surname,int id,string faculty,string department,string year)
        {
            InitializeComponent();
            this.faculty = faculty;
            this.department = department;
            var query = "";
            DataRow departmentName;
            if (department=="")
            {
                departmentLabel.Content = "Department is unassigned";
            }
            else
            {
                query = $"select * from departments where id={department}";
                departmentName = Database.query(query, new List<cmdParameterType>()).Rows[0];
                departmentLabel.Content = departmentName["name"];

            }
            if (faculty=="")
            {
                facultyLabel.Content = "Faculty is unassigned";
            }
            else
            {            
                query = $"select * from faculties where id={faculty}";
                var facultyName = Database.query(query, new List<cmdParameterType>()).Rows[0];
                facultyLabel.Content = facultyName["name"];
            }
            nameLabel.Content = name;
            surnameLabel.Content = surname;
            idnumberLabel.Content=id;
            
            
            yearLabel.Content = year;

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
