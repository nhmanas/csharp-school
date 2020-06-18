﻿using School_Automation_Collab.sql;
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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        DataTable studentList=new DataTable();
        DataTable teacherList = new DataTable();
        DataTable facultyList = new DataTable();
        DataTable departmentList = new DataTable();
        DataTable courseList = new DataTable();
        bool initFinished = false;
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


            var query = "SELECT * FROM students join access on access.user_id=students.number";
            var check = Database.query(query);
            if (check==null)
            {
                new WarningWindow().Show();
                this.Close();
            }            
            studentList = check;

            query = "select * from instructors join access on access.user_id=instructors.number where status=0";
            check = Database.query(query);
            if (check == null)
            {
                new WarningWindow().Show();
                this.Close();
            }
            teacherList = check;
            foreach (DataRow item in teacherList.Rows)
            {
                teacherComboApprove.Items.Add(item["number"]);
            }

            for (int i = 0; i < studentList.Rows.Count; i++)
            {
                studentCombo.Items.Add(studentList.Rows[i]["number"]);
                studentComboC.Items.Add(studentList.Rows[i]["number"]);
            }

            query = "select * from faculties";
            check = Database.query(query);
            if (check == null)
            {
                new WarningWindow().Show();
                this.Close();
            }
            facultyList = check;
            facultyCombo.SelectedIndex = 0;
            for (int i = 0; i < facultyList.Rows.Count; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = facultyList.Rows[i]["name"].ToString();
                item.Value = facultyList.Rows[i]["id"];
                facultyCombo.Items.Add(item);
            }

            query = "select * from departments";
            check = Database.query(query);
            if (check == null)
            {
                new WarningWindow().Show();
                this.Close();
            }
            departmentList = check;

            query = "select * from courses";
            check = Database.query(query);
            if (check == null)
            {
                new WarningWindow().Show();
                this.Close();
            }
            courseList = check;



            initFinished = true;
            

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


        private void logout_click(object sender, RoutedEventArgs e)
        {
            new WarningWindow(MainWindow.colorOK, "OK", "Logout successfull", new MainWindow()).Show();
            this.Close();
        }

        private void studentCombo_changed(object sender, SelectionChangedEventArgs e)
        {

            if (studentCombo.SelectedIndex==0)
            {
                nameLabel1.Content = "";
                surnameLabel1.Content = "";
                idnumberLabel1.Content = "";
                yearLabel1.Content = "";
            }
            else
            {

                nameLabel1.Content = studentList.Rows[studentCombo.SelectedIndex - 1]["name"];
                surnameLabel1.Content = studentList.Rows[studentCombo.SelectedIndex - 1]["surname"];
                idnumberLabel1.Content = studentList.Rows[studentCombo.SelectedIndex - 1]["number"];
                yearLabel1.Content = studentList.Rows[studentCombo.SelectedIndex - 1]["year"];
            }
        }

        private void enroll_Click(object sender, RoutedEventArgs e)
        {
            course_info_Click(sender, e);
            if (studentCombo.SelectedIndex==0 || courseCombo.SelectedIndex==0 || departmentCombo.SelectedIndex==0 || facultyCombo.SelectedIndex==0)
            {
                new WarningWindow(MainWindow.colorWarning,"Wrong Selection", "Select Faculty, Department, Course \nand Student").Show();
                return;
            }
            var query = "select * from notes join courses on notes.course_id = courses.id where student_id = @student_id";
            var lstParams = new List<cmdParameterType> { new cmdParameterType("@student_id", idnumberLabel1.Content) };
            var check = Database.query(query, lstParams);
            if (check == null)
            {
                new WarningWindow(MainWindow.colorError, "DB Error", "Updating error").Show();
                return;
            }
            if (check.Rows.Count==0)
            {
                query = "insert into notes (course_id,student_id) values (@course_id,@student_id)";
                lstParams.Add(new cmdParameterType("@course_id", (courseCombo.SelectedItem as ComboboxItem).Value.ToString()));
                var check2 = Database.query(query, lstParams);
                if (check2 == null)
                {
                    new WarningWindow(MainWindow.colorError, "DB Error", "Updating error").Show();
                    return;
                }
                
            }
            else
            {
                query = "select * from courses where id="+(courseCombo.SelectedItem as ComboboxItem).Value.ToString();
                var check2 = Database.query(query);
                if (check2 == null)
                {
                    new WarningWindow(MainWindow.colorError, "DB Error", "Updating error").Show();
                    return;
                }
                var course = check2.Rows[0];
                query = "select * from notes join courses on notes.course_id = courses.id where student_id = @student_id and courses.day=@day and courses.start_end=@start_end";
                lstParams = new List<cmdParameterType>
                {
                    new cmdParameterType("@day", course["day"].ToString()),
                    new cmdParameterType("@student_id",idnumberLabel1.Content),
                     new cmdParameterType("@start_end",course["start_end"].ToString())

                };
                check2 = Database.query(query, lstParams);
                if (check2 == null)
                {
                    new WarningWindow(MainWindow.colorError, "DB Error", "Couldnt check student's existing classes").Show();
                    return;
                }
                if (check2.Rows.Count!=0)
                {
                    new WarningWindow(MainWindow.colorWarning, "Can't add", "Student already has a class that day and time").Show();
                    return;
                }
                else
                {
                    query = "insert into notes (course_id,student_id) values (@course_id,@student_id)";
                    lstParams = new List<cmdParameterType>
                    {
                        new cmdParameterType("@course_id",(courseCombo.SelectedItem as ComboboxItem).Value.ToString()),
                        new cmdParameterType("@student_id",idnumberLabel1.Content)
                    };
                    check2=Database.query(query, lstParams);
                    if (check2 == null)
                    {
                        new WarningWindow(MainWindow.colorError, "DB Error", "Couldnt insert to notes db").Show();
                        return;
                    }
                }
            }
            new WarningWindow(MainWindow.colorOK, "Success", "Successfully enrolled student to selected class").Show();
            return;

        }

        private void facultyCombo_changed(object sender, EventArgs e)
        {
            if (!initFinished)
            {
                return;
            }

            departmentCombo.SelectedIndex = 0;
            int departmentCount = departmentCombo.Items.Count - 1;
            for (int i = 0; i < departmentCount; i++)
            {
                departmentCombo.Items.Remove(departmentCombo.Items[1]);
            }

            courseCombo.SelectedIndex = 0;
            int courseCount = courseCombo.Items.Count - 1;
            for (int i = 0; i < courseCount; i++)
            {
                courseCombo.Items.Remove(courseCombo.Items[1]);
            }

            if (facultyCombo.SelectedIndex!=0)
            {
                foreach (DataRow departmentListItem in departmentList.Rows)
                {
                    if ((facultyCombo.SelectedItem as ComboboxItem).Value.ToString() == departmentListItem["faculty_id"].ToString())
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = departmentListItem["name"].ToString();
                        item.Value = departmentListItem["id"];
                        departmentCombo.Items.Add(item);
                    }

                }
            }
        }

        private void departmentCombo_Changed(object sender, EventArgs e)
        {
            courseCombo.SelectedIndex = 0;
            int courseCount = courseCombo.Items.Count - 1;
            for (int i = 0; i < courseCount; i++)
            {
                courseCombo.Items.Remove(courseCombo.Items[1]);
            }
            
            if (departmentCombo.SelectedIndex!=0)
            {
                foreach (DataRow courseItem in courseList.Rows)
                {
                    if ((departmentCombo.SelectedItem as ComboboxItem).Value.ToString()== courseItem["department_id"].ToString())
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = courseItem["name"].ToString();
                        item.Value = courseItem["id"];
                        courseCombo.Items.Add(item);
                    }
                }
            }
        }

        private void courseCombo_Changed(object sender, EventArgs e)
        {
            if (courseCombo.SelectedIndex!=0)
            {

            }
        }

        private void studentComboC_Changed(object sender, EventArgs e)
        {
            if (studentComboC.SelectedIndex!=0)
            {
                studentnameBox.Text = studentList.Rows[studentComboC.SelectedIndex - 1]["name"].ToString();
                studentsurnameBox.Text = studentList.Rows[studentComboC.SelectedIndex - 1]["surname"].ToString();
                idnumberBox.Text = studentList.Rows[studentComboC.SelectedIndex - 1]["user_id"].ToString();
                yearBox.Text = studentList.Rows[studentComboC.SelectedIndex - 1]["year"].ToString();
            }
        }

        private void teacherokButton_Click(object sender, RoutedEventArgs e)
        {
            if (teacherComboApprove.SelectedIndex==0)
            {
                new WarningWindow(MainWindow.colorWarning, "Selection Needed", "Select a teacher to continue").Show();
                return;
            }
            var query = "update instructors set status=1 where number=@number";
            var lstParams = new List<cmdParameterType> { new cmdParameterType("@number", teacherComboApprove.SelectedItem) };
            var check = Database.query(query, lstParams);
            if (check==null)
            {
                new WarningWindow(MainWindow.colorError, "DB Error", "Updating error").Show();
                return;
            }
            if (!updateTeacherApprove())
            {
                return;
            }
            new WarningWindow(MainWindow.colorOK, "Success", "Teacher Approved").Show();


        }
        private void teacherDeny_Click(object sender, RoutedEventArgs e)
        {
            if (teacherComboApprove.SelectedIndex == 0)
            {
                new WarningWindow(MainWindow.colorWarning, "Selection Needed", "Select a teacher to continue").Show();
                return;
            }
            var query = "delete from instructors where number=@number; delete from access where user_id=@number";
            var lstParams = new List<cmdParameterType> { new cmdParameterType("@number", teacherComboApprove.SelectedItem) };
            var check = Database.query(query, lstParams);
            if (check == null)
            {
                new WarningWindow(MainWindow.colorError, "DB Error", "Updating error").Show();
                return;
            }
            if (!updateTeacherApprove())
            {
                return;
            }
            new WarningWindow(MainWindow.colorOK, "Success", "Teacher Denied").Show();
        }
        private bool updateTeacherApprove()
        {
            teacherComboApprove.SelectedIndex = 0;
            int count = teacherComboApprove.Items.Count - 1;
            for (int i = 0; i < count; i++)
            {
                teacherComboApprove.Items.Remove(teacherComboApprove.Items[1]);
            }
            var query = "select * from instructors join access on access.user_id=instructors.number where status=0";
            var check = Database.query(query);
            if (check == null)
            {
                new WarningWindow(MainWindow.colorError, "DB Error", "Select teachers error").Show();
                return false;
            }
            teacherList = check;
            foreach (DataRow item in teacherList.Rows)
            {
                teacherComboApprove.Items.Add(item["number"]);
            }
            return true;
        }

        private void course_info_Click(object sender, RoutedEventArgs e)
        {
            var faculty_id      = (facultyCombo.SelectedItem as ComboboxItem).Value.ToString();
            var department_id   = (departmentCombo.SelectedItem as ComboboxItem).Value.ToString();
            var course_id       = (courseCombo.SelectedItem as ComboboxItem).Value.ToString();

            var query = "select courses.*, access.name as 'instructor_name' from courses join instructors on courses.instructor_id = instructors.id join access on access.user_id=instructors.number where courses.id=@course_id";
            var lstParams = new List<cmdParameterType> { new cmdParameterType("@course_id", course_id) };
            var check = Database.query(query, lstParams);
            if (check==null)
            {
                new WarningWindow(MainWindow.colorError, "DB error", "Connection error").Show();
                return;
            }
            instructornameLabel.Content = check.Rows[0]["instructor_name"].ToString();
            classcodeLabel.Content = check.Rows[0]["code"].ToString();
            availablehoursLabel.Content = check.Rows[0]["start_end"].ToString()=="1"?"9:00-12:00":"13:00-16:00";
            availabledayLabel.Content = check.Rows[0]["day"].ToString();
        }
    }
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
