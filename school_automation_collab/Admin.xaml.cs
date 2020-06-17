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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        DataTable studentList=new DataTable();
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
            if (studentCombo.SelectedIndex==0 || courseCombo.SelectedIndex==0 || departmentCombo.SelectedIndex==0 || facultyCombo.SelectedIndex==0)
            {
                new WarningWindow(MainWindow.colorWarning,"Wrong Selection", "Select Faculty, Department, Course \nand Student").Show();
                return;
            }
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
