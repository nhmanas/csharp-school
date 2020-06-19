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
        int instructorID;
        public Teacher()
        {
            InitializeComponent();
        }
        public Teacher(string name,string surname,string number,string faculty,string department)
        {
            InitializeComponent();
            nameLabel.Content = name;
            surnameLabel.Content = surname;
            idnumberLabel.Content = number;
            var query = "";
            DataRow departmentName;

            if (department == "")
            {
                departmentLabel.Content = "Department is unassigned";
            }
            else
            {
                query = $"select * from departments where id={department}";
                departmentName = Database.query(query).Rows[0];
                departmentLabel.Content = departmentName["name"];

            }
            if (faculty == "")
            {
                facultyLabel.Content = "Faculty is unassigned";
            }
            else
            {
                query = $"select * from faculties where id={faculty}";
                var facultyName = Database.query(query).Rows[0];
                facultyLabel.Content = facultyName["name"];
            }
            


            query = "select * from courses join instructors on courses.instructor_id = instructors.id where instructors.number=@id";
            var lstParams = new List<cmdParameterType> { new cmdParameterType("@id", number) };
            var check = Database.query(query, lstParams);
            if (check==null)
            {
                new WarningWindow().Show();
                this.Close();
            }
            courseList = check;
            foreach (DataRow item in courseList.Rows)
            {
                ComboboxItem comboItem = new ComboboxItem();
                comboItem.Text = item["name"].ToString();
                comboItem.Value = item["id"];
                selectcourseCombo.Items.Add(comboItem);
                switch (item["day"].ToString().ToLower())
                {
                    case "monday":
                        class_morning_afternoon((int)item["start_end"], mon1, mon2, item["code"].ToString()+ "\n"+ item["name"].ToString());
                        break;
                    case "tuesday":
                        class_morning_afternoon((int)item["start_end"], tue1, tue2, item["code"].ToString() + "\n" + item["name"].ToString());
                        break;
                    case "wednesday":
                        class_morning_afternoon((int)item["start_end"], wed1, wed2, item["code"].ToString() + "\n" + item["name"].ToString());
                        break;
                    case "thursday":
                        class_morning_afternoon((int)item["start_end"], thu1, thu2, item["code"].ToString() + "\n" + item["name"].ToString());
                        break;
                    case "friday":
                        class_morning_afternoon((int)item["start_end"], fri1, fri2, item["code"].ToString() + "\n" + item["name"].ToString());
                        break;
                    default:
                        break;
                }
            }

        }
        public void class_morning_afternoon(int clock, Label morning, Label afternoon,string text)
        {
            switch (clock)
            {
                case 1:
                    morning.Content = text;
                    break;
                case 2:
                    afternoon.Content = text;
                    break;
                default:
                    break;
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

        private void selectcourseCombo_changed(object sender, EventArgs e)
        {
            
        }

        private void courseStudents_Clicked(object sender, RoutedEventArgs e)
        {
            /*if (selectcourseCombo.SelectedIndex==0)
            {
                new WarningWindow("")
            }
            string courseID = (selectcourseCombo.SelectedItem as ComboboxItem).Value.ToString();
            var query = "select * from notes where "*/
        }
    }
}
