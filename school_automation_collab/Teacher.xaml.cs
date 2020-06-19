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
                comboItem.Text = item["name"].ToString() + " ("+ item["code"].ToString()+")";
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
        public static void class_morning_afternoon(int clock, Label morning, Label afternoon,string text)
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
            if (selectcourseCombo.SelectedIndex==0)
            {
                new WarningWindow(MainWindow.colorWarning, "Cant list", "Please select a course first").Show();
                return;
            }
            if (!refresh())
            {
                return;
            }
            
        }
            private bool refresh()
        {
            string course_id = (selectcourseCombo.SelectedItem as ComboboxItem).Value.ToString();

            var query = @"select 

                        notes.id,
                        access.user_id as 'Student Number',
                        access.name as 'Student Name',
                        access.surname as 'Student Surname',
                        notes.note1 as 'Midterm',
                        notes.note2 as 'Final'

                        from notes join access on access.user_id=notes.student_id 

                        where notes.course_id=@course_id";
            var lstParams = new List<cmdParameterType> {
                new cmdParameterType("@course_id",course_id)
                };
            var check = Database.query(query, lstParams);
            if (check == null)
            {
                new WarningWindow(MainWindow.colorError, "DB Error", "Couldn't get students").Show();
                return false;
            }
            if (check.Rows.Count == 0)
            {
                new WarningWindow(MainWindow.colorWarning, "No students", "You don't have students in this class").Show();
            }
            gradestudentsGrid.DataContext = check.DefaultView;
            return true;
        }

        private void gradestudentsGrid_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (gradestudentsGrid.SelectedItems.Count==0)
            {
                return;
            }
            DataRowView selectedRow = gradestudentsGrid.SelectedItem as DataRowView;
            midtermgradeBox.Text = selectedRow["Midterm"].ToString();
            finalgradeBox.Text = selectedRow["Final"].ToString();
        }

        private void update_Notes(object sender, RoutedEventArgs e)
        {
            if (gradestudentsGrid.SelectedItems.Count !=1)
            {
                new WarningWindow(MainWindow.colorWarning, "Wrong selection", "Select only one student").Show();
                return;
            }


            int midterm;
            int final;
            if ((!int.TryParse(midtermgradeBox.Text,out midterm) && midtermgradeBox.Text!="") || (!int.TryParse(finalgradeBox.Text, out final) && finalgradeBox.Text!=""))
            {
                new WarningWindow(MainWindow.colorWarning, "Wrong Input", "Enter number value").Show();
                return;
            }
            if (midterm<0 || midterm>100 || final<0 || final>100)
            {
                new WarningWindow(MainWindow.colorWarning, "Wrong Input", "Midterm and final must be between 0-100").Show();
                return;
            }
            DataRowView selectedRow = gradestudentsGrid.SelectedItem as DataRowView;
            var query="update notes set note1=@note1, note2=@note2 where id=@id";
            var lstParams = new List<cmdParameterType>
            {
                new cmdParameterType("@note1",midtermgradeBox.Text==""?null:midtermgradeBox.Text),
                new cmdParameterType("@note2",finalgradeBox.Text==""?null:finalgradeBox.Text),
                new cmdParameterType("@id",selectedRow["id"].ToString())

            };
            var check = Database.query(query, lstParams);
            if (check == null)
            {
                new WarningWindow(MainWindow.colorError, "DB Error", "Couldn't update notes").Show();
                return;
            }
            if (!refresh())
            {
                return;
            }
            new WarningWindow(MainWindow.colorOK, "Success", "Note Updated").Show();
        }
    }
}
