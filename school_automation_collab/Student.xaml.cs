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


            query = @"select 

                    courses.code,
                    courses.name,
                    access.name as 'Teacher Name',
                    courses.start_end,
                    courses.day,
                    notes.note1,
                    notes.note2
                    from courses join notes on courses.id = notes.course_id join instructors on instructors.id=courses.instructor_id join access on access.user_id = instructors.number
                    where notes.student_id=@id";
            var lstParams = new List<cmdParameterType> { new cmdParameterType("@id", id) };
            var check = Database.query(query, lstParams);
            if (check == null)
            {
                new WarningWindow().Show();
                this.Close();
            }
            var courseList = check;
            foreach (DataRow item in courseList.Rows)
            {
                
                switch (item["day"].ToString().ToLower())
                {
                    case "monday":
                        Teacher.class_morning_afternoon((int)item["start_end"], mon1, mon2, item["code"].ToString() + "\n" + item["name"].ToString());
                        break;
                    case "tuesday":
                        Teacher.class_morning_afternoon((int)item["start_end"], tue1, tue2, item["code"].ToString() + "\n" + item["name"].ToString());
                        break;
                    case "wednesday":
                        Teacher.class_morning_afternoon((int)item["start_end"], wed1, wed2, item["code"].ToString() + "\n" + item["name"].ToString());
                        break;
                    case "thursday":
                        Teacher.class_morning_afternoon((int)item["start_end"], thu1, thu2, item["code"].ToString() + "\n" + item["name"].ToString());
                        break;
                    case "friday":
                        Teacher.class_morning_afternoon((int)item["start_end"], fri1, fri2, item["code"].ToString() + "\n" + item["name"].ToString());
                        break;
                    default:
                        break;
                }
                
            }
            DataTable dtCloned = courseList.Clone();
            dtCloned.Columns["start_end"].DataType = typeof(string);
            
            foreach (DataRow item in courseList.Rows)
            {
                
                dtCloned.ImportRow(item);
            }
            foreach (DataRow item in dtCloned.Rows)
            {

                item["start_end"] = item["start_end"].ToString() == "1" ? "9:00-12:00" : "13:00-16:00";
            }
            dtCloned.Columns["start_end"].ColumnName = "Hours";
            dtCloned.Columns["note1"].ColumnName = "Midterm";
            dtCloned.Columns["note2"].ColumnName = "Final";


            examresultsGrid.DataContext = dtCloned.DefaultView;

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
