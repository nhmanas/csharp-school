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
            if (!instructornameCombo_update())
            {
                return;
            }

            for (int i = 0; i < studentList.Rows.Count; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = studentList.Rows[i]["user_id"].ToString();
                item.Value = studentList.Rows[i]["user_id"];
                studentCombo.Items.Add(item);
                studentComboC.Items.Add(item);
                
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
            facultyComboC.SelectedIndex = 0;
            studentfacultyComboC.SelectedIndex = 0;
            for (int i = 0; i < facultyList.Rows.Count; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = facultyList.Rows[i]["name"].ToString();
                item.Value = facultyList.Rows[i]["id"];
                facultyCombo.Items.Add(item);
                facultyComboC.Items.Add(item);
                studentfacultyComboC.Items.Add(item);
                teacherfacultyComboC.Items.Add(item);
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
        private bool update_faculty_department_course()
        {
            var query = "select * from faculties";
            var check = Database.query(query);
            if (check == null)
            {
                new WarningWindow(MainWindow.colorError, "DB Error", "Couldn't select faculties").Show();
                return false;
            }
            facultyList = check;
            facultyCombo.SelectedIndex = 0;
            facultyCombo_changed(new object(), new EventArgs());
            facultyComboC.SelectedIndex = 0;
            facultyComboC_changed(new object(), new EventArgs());
            studentfacultyComboC.SelectedIndex = 0;
            studentfacultyComboC_changed(new object(), new EventArgs());

            int m = facultyCombo.Items.Count;
            for (int i = 1; i < m; i++)
            {
                facultyCombo.Items.Remove(facultyCombo.Items[1]);
                facultyComboC.Items.Remove(facultyComboC.Items[1]);
            }


            for (int i = 0; i < facultyList.Rows.Count; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = facultyList.Rows[i]["name"].ToString();
                item.Value = facultyList.Rows[i]["id"];
                facultyCombo.Items.Add(item);
                facultyComboC.Items.Add(item);
            }
            


            query = "select * from departments";
            check = Database.query(query);
            if (check == null)
            {
                new WarningWindow(MainWindow.colorError, "DB Error", "Couldn't select departments").Show();
                return false;
            }
            departmentList = check;

            query = "select * from courses";
            check = Database.query(query);
            if (check == null)
            {
                new WarningWindow(MainWindow.colorError, "DB Error", "Couldn't select courses").Show();
                return false;
            }
            courseList = check;
            return true;
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
            if (availabledayLabel.Content.ToString() == "Needs teacher assignment")
            {
                new WarningWindow(MainWindow.colorWarning, "Cant enroll", "Specified class has no teacher").Show();
                return;
            }
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
        private void facultyComboC_changed(object sender, EventArgs e)
        {
            if (!initFinished)
            {
                return;
            }

            departmentComboC.SelectedIndex = 0;
            int departmentCount = departmentComboC.Items.Count - 1;
            for (int i = 0; i < departmentCount; i++)
            {
                departmentComboC.Items.Remove(departmentComboC.Items[1]);
            }

            courseComboC.SelectedIndex = 0;
            int courseCount = courseComboC.Items.Count - 1;
            for (int i = 0; i < courseCount; i++)
            {
                courseComboC.Items.Remove(courseComboC.Items[1]);
            }

            if (facultyComboC.SelectedIndex != 0)
            {
                foreach (DataRow departmentListItem in departmentList.Rows)
                {
                    if ((facultyComboC.SelectedItem as ComboboxItem).Value.ToString() == departmentListItem["faculty_id"].ToString())
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = departmentListItem["name"].ToString();
                        item.Value = departmentListItem["id"];
                        departmentComboC.Items.Add(item);
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
        private void departmentComboC_Changed(object sender, EventArgs e)
        {
            courseComboC.SelectedIndex = 0;
            int courseCount = courseComboC.Items.Count - 1;
            for (int i = 0; i < courseCount; i++)
            {
                courseComboC.Items.Remove(courseComboC.Items[1]);
            }

            if (departmentComboC.SelectedIndex != 0)
            {
                foreach (DataRow courseItem in courseList.Rows)
                {
                    if ((departmentComboC.SelectedItem as ComboboxItem).Value.ToString() == courseItem["department_id"].ToString())
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = courseItem["name"].ToString();
                        item.Value = courseItem["id"];
                        courseComboC.Items.Add(item);
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
                int index = 0;
                for (int i = 1; i < studentList.Rows.Count; i++)
                {
                    if (studentList.Rows[i]["number"].ToString()==(studentComboC.SelectedItem as ComboboxItem).Value.ToString())
                    {
                        index = i;
                        break;
                    }
                }
                studentnameBox.Text = studentList.Rows[index]["name"].ToString();
                studentsurnameBox.Text = studentList.Rows[index]["surname"].ToString();
                idnumberBox.Text = studentList.Rows[index]["user_id"].ToString();
                yearBox.Text = studentList.Rows[index]["year"].ToString();
                studentfacultyComboC.SelectedIndex= studentList.Rows[index]["faculty_id"].ToString()==""?0: (int)studentList.Rows[index]["faculty_id"];
                studentfacultyComboC_changed(new object(), new EventArgs());
                var index2 = 0;
                for (int i = 1; i < studentdepartmentComboC.Items.Count; i++)
                {
                    if ((int)studentList.Rows[index]["department_id"]==(int)(studentdepartmentComboC.Items[i] as ComboboxItem).Value)
                    {
                        index2 = i;
                    }
                }
                studentdepartmentComboC.SelectedIndex = index2;
            }
            else
            {
                studentDetailClear();
            }
        }

        private void teacherokButton_Click(object sender, RoutedEventArgs e)
        {
            if (teacherComboApprove.SelectedIndex==0)
            {
                new WarningWindow(MainWindow.colorWarning, "Selection Needed", "Select a teacher to continue").Show();
                return;
            }
            if (teacherfacultyComboC.SelectedIndex==0 || teacherdepartmentComboC.SelectedIndex==0 || teacherNameBox.Text=="" || teacherSurnameBox.Text=="")
            {
                new WarningWindow(MainWindow.colorWarning, "Fill all", "Fill all the necessary platforms").Show();
                return;
            }
            var query = @"update instructors set status=1 where number=@number; 
                        update access set name=@name, surname=@surname, faculty_id=@faculty_id, department_id=@department_id where user_id=@number";
            var lstParams = new List<cmdParameterType> { 
                new cmdParameterType("@number", teacherComboApprove.SelectedItem),
                new cmdParameterType("@name", teacherNameBox.Text),
                new cmdParameterType("@surname", teacherSurnameBox.Text),
                new cmdParameterType("@faculty_id", (teacherfacultyComboC.SelectedItem as ComboboxItem).Value),
                new cmdParameterType("@department_id", (teacherdepartmentComboC.SelectedItem as ComboboxItem).Value),
            };
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
            if (!instructornameCombo_update())
            {
                return;
            }
            teacherComboApprove_Changed(sender, e);
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
            if (courseCombo.SelectedIndex == 0)
            {
                new WarningWindow(MainWindow.colorWarning, "Can't update", "Please select course first").Show();
                return;
            }
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
            if (check.Rows.Count==0)
            {
                instructornameLabel.Content = "Needs teacher assignment";
                classcodeLabel.Content = "Needs teacher assignment";
                availablehoursLabel.Content = "Needs teacher assignment";
                availabledayLabel.Content = "Needs teacher assignment";
                
                return;
            }
            instructornameLabel.Content = check.Rows[0]["instructor_name"].ToString();
            classcodeLabel.Content = check.Rows[0]["code"].ToString();
            availablehoursLabel.Content = check.Rows[0]["start_end"].ToString()=="1"?"9:00-12:00":"13:00-16:00";
            availabledayLabel.Content = check.Rows[0]["day"].ToString();
        }
        private bool instructornameCombo_update()
        {
            var query = "select instructors.*, access.name from instructors join access on access.user_id=instructors.number where instructors.status=1";

            var check = Database.query(query);
            if (check==null)
            {
                if (initFinished)
                {
                    new WarningWindow(MainWindow.colorError, "DB error", "Couldnt select from instructors");
                }
                else
                {
                    new WarningWindow().Show();
                    this.Close();
                }
                return false;
            }
            var teacherListApproved = check;
            instructornameCombo.SelectedIndex = 0;
            int instructorCount = instructornameCombo.Items.Count - 1;
            for (int i = 0; i < instructorCount; i++)
            {
                instructornameCombo.Items.Remove(instructornameCombo.Items[1]);
            }
            for (int i = 0; i < teacherListApproved.Rows.Count; i++)
            {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = teacherListApproved.Rows[i]["number"].ToString();
                    item.Value = teacherListApproved.Rows[i]["id"];
                    instructornameCombo.Items.Add(item);
            }
            return true;
        }
        private void studentDetailClear()
        {
            studentnameBox.Text = "";
            studentsurnameBox.Text = "";
            idnumberBox.Text = "";
            yearBox.Text = "";

            studentdepartmentComboC.SelectedIndex = 0;
            int departmentCount = studentdepartmentComboC.Items.Count - 1;
            for (int i = 0; i < departmentCount; i++)
            {
                studentdepartmentComboC.Items.Remove(studentdepartmentComboC.Items[1]);
            }

            studentfacultyComboC.SelectedIndex = 0;

        }

        private void list_all_students_checked(object sender, RoutedEventArgs e)
        {
            studentDetailClear();
            studentComboC.SelectedIndex = 0;
            int instructorCount = studentComboC.Items.Count - 1;
            for (int i = 0; i < instructorCount; i++)
            {
                studentComboC.Items.Remove(studentComboC.Items[1]);
            }
            for (int i = 0; i < studentList.Rows.Count; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = studentList.Rows[i]["number"].ToString();
                item.Value = studentList.Rows[i]["number"];
                studentComboC.Items.Add(item);
            }

        }

        private void list_infoless_students_checked(object sender, RoutedEventArgs e)
        {
            studentDetailClear();
            studentComboC.SelectedIndex = 0;
            int instructorCount = studentComboC.Items.Count - 1;
            for (int i = 0; i < instructorCount; i++)
            {
                studentComboC.Items.Remove(studentComboC.Items[1]);
            }
            for (int i = 0; i < studentList.Rows.Count; i++)
            {
                if (
                    studentList.Rows[i]["surname"].ToString() == "" ||
                    studentList.Rows[i]["faculty_id"].ToString() == "" ||
                    studentList.Rows[i]["department_id"].ToString() == ""
                    )
                {

                    ComboboxItem item = new ComboboxItem();
                    item.Text = studentList.Rows[i]["number"].ToString();
                    item.Value = studentList.Rows[i]["number"];
                    studentComboC.Items.Add(item);
                }
            }

        }

        private void studentfacultyComboC_changed(object sender, EventArgs e)
        {
            if (!initFinished)
            {
                return;
            }

            studentdepartmentComboC.SelectedIndex = 0;
            int departmentCount = studentdepartmentComboC.Items.Count - 1;
            for (int i = 0; i < departmentCount; i++)
            {
                studentdepartmentComboC.Items.Remove(studentdepartmentComboC.Items[1]);
            }


            if (studentfacultyComboC.SelectedIndex != 0)
            {
                foreach (DataRow departmentListItem in departmentList.Rows)
                {
                    if ((studentfacultyComboC.SelectedItem as ComboboxItem).Value.ToString() == departmentListItem["faculty_id"].ToString())
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = departmentListItem["name"].ToString();
                        item.Value = departmentListItem["id"];
                        studentdepartmentComboC.Items.Add(item);
                    }

                }
            }
            
        }
        private void teacherfacultyComboC_Changed(object sender, EventArgs e)
        {
            if (!initFinished)
            {
                return;
            }

            teacherdepartmentComboC.SelectedIndex = 0;
            int departmentCount = teacherdepartmentComboC.Items.Count - 1;
            for (int i = 0; i < departmentCount; i++)
            {
                teacherdepartmentComboC.Items.Remove(teacherdepartmentComboC.Items[1]);
            }


            if (teacherfacultyComboC.SelectedIndex != 0)
            {
                foreach (DataRow departmentListItem in departmentList.Rows)
                {
                    if ((teacherfacultyComboC.SelectedItem as ComboboxItem).Value.ToString() == departmentListItem["faculty_id"].ToString())
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = departmentListItem["name"].ToString();
                        item.Value = departmentListItem["id"];
                        teacherdepartmentComboC.Items.Add(item);
                    }


                }
            } 
        }
        private void teacherComboApprove_Changed(object sender, EventArgs e)
        {
            if (teacherComboApprove.SelectedIndex==0)
            {
                teacherNameBox.Text = "";
                teacherSurnameBox.Text = "";
                idnumberLabel2.Content = "";
                teacherfacultyComboC.SelectedIndex = 0;
                teacherfacultyComboC_Changed(sender, e);
                return;
            }
            var query = "select * from access where user_id=@user_id";
            var lstParams = new List<cmdParameterType>
            {
                new cmdParameterType("@user_id",teacherComboApprove.SelectedItem)
            };
            var check = Database.query(query, lstParams);
            if (check==null)
            {
                new WarningWindow(MainWindow.colorError, "DB error", "Couldnt get info from the teacher").Show();
                teacherComboApprove.SelectedIndex = 0;
                return;
            }
            teacherNameBox.Text = check.Rows[0]["name"].ToString();
            teacherSurnameBox.Text = check.Rows[0]["surname"].ToString();
            idnumberLabel2.Content = check.Rows[0]["user_id"].ToString();
        }

        private void update_Student_Click(object sender, RoutedEventArgs e)
        {
            var query = "";
            var lstParams = new List<cmdParameterType>();
            var check = new DataTable();
            if (studentComboC.SelectedIndex==0)
            {
                new WarningWindow(MainWindow.colorWarning, "Cant approve", "You must select a student first").Show();
                return;
            }
            if (
                studentnameBox.Text=="" || 
                studentsurnameBox.Text=="" || 
                idnumberBox.Text=="" || 
                studentfacultyComboC.SelectedIndex==0 || 
                studentdepartmentComboC.SelectedIndex==0 ||
                yearBox.Text==""
                )
            {
                new WarningWindow(MainWindow.colorWarning, "Fill the blanks", "You must fill all fields").Show();
                return;
            }
            int n;

            if (!int.TryParse(idnumberBox.Text,out n) || !int.TryParse(yearBox.Text,out n))
            {
                new WarningWindow(MainWindow.colorWarning, "Text in number field", "ID and year must be numbers");
                return;
            }
            var a = (studentComboC.SelectedItem as ComboboxItem).Value.ToString();
            if (idnumberBox.Text != (studentComboC.SelectedItem as ComboboxItem).Value.ToString())
            {
                query = "select * from access where user_id=@user_id";
                lstParams = new List<cmdParameterType> { new cmdParameterType("@user_id", idnumberBox.Text) };
                check = Database.query(query, lstParams);
                if (check == null)
                {
                    new WarningWindow(MainWindow.colorError, "DB error", "Couldnt check existing users").Show();
                    return;
                }
                if (check.Rows.Count != 0)
                {

                    new WarningWindow(MainWindow.colorWarning, "Can't add", "User with the given id number already exists").Show();
                    return;


                }
            }
            query = @"UPDATE access set 
                        access.user_id = @new_id,
                        access.name=@new_name,
                        access.surname=@new_surname,
                        access.faculty_id=@faculty_id,
                        access.department_id=@department_id
                    where access.user_id=@old_id;
                    update notes set student_id=@new_id where student_id=@old_id;
                    update students set number = @new_id where number=@old_id";
            lstParams = new List<cmdParameterType>
            {
                new cmdParameterType("@new_id",idnumberBox.Text),
                new cmdParameterType("@old_id",(studentComboC.SelectedItem as ComboboxItem).Value),
                new cmdParameterType("@new_name",studentnameBox.Text),
                new cmdParameterType("@new_surname",studentsurnameBox.Text),
                new cmdParameterType("@faculty_id",(studentfacultyComboC.SelectedItem as ComboboxItem).Value),
                new cmdParameterType("@department_id",(studentdepartmentComboC.SelectedItem as ComboboxItem).Value)
,
            };
            check = Database.query(query, lstParams);
            if (check==null)
            {
                new WarningWindow(MainWindow.colorError, "DB error", "Couldnt update user").Show();
                return;
            }

            if (!student_comboboxes_update())
            {
                return;
            }


            new WarningWindow(MainWindow.colorOK, "Success", "Successfully updated student").Show();

        }
        private bool student_comboboxes_update()
        {
            var  query = "SELECT * FROM students join access on access.user_id=students.number";
            var check = Database.query(query);
            if (check == null)
            {
                new WarningWindow(MainWindow.colorError, "DB error", "Couldnt update current session").Show();
                return false;
            }
            studentList = check;
            studentCombo.SelectedIndex = 0;
            studentComboC.SelectedIndex = 0;
            var n = studentComboC.Items.Count - 1;
            var m = studentCombo.Items.Count - 1;
            for (int i = 0; i < n; i++)
            {
                studentComboC.Items.Remove(studentComboC.Items[1]);
            }
            for (int i = 0; i < m; i++)
            {
                studentCombo.Items.Remove(studentCombo.Items[1]);
            }
            for (int i = 0; i < studentList.Rows.Count; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = studentList.Rows[i]["user_id"].ToString();
                item.Value = studentList.Rows[i]["user_id"];
                studentCombo.Items.Add(item);
                studentComboC.Items.Add(item);

            }
            var index = 0;
            for (int i = 1; i < studentComboC.Items.Count; i++)
            {
                if ((int)(studentComboC.Items[i] as ComboboxItem).Value == int.Parse(idnumberBox.Text))
                {
                    index = i;
                }
            }
            studentComboC.SelectedIndex = index;
            return true;
        }

        private void delete_student(object sender, RoutedEventArgs e)
        {
            if (studentComboC.SelectedIndex == 0)
            {
                new WarningWindow(MainWindow.colorWarning, "Cant delete", "You must select a student first").Show();
                return;
            }
            var query = @"
                    delete from access where access.user_id=@id;
                    delete from notes where notes.student_id=@id;
                    delete from students where students.number=@id";
            var lstParams = new List<cmdParameterType> { new cmdParameterType("@id", (studentComboC.SelectedItem as ComboboxItem).Value) };
            var check = Database.query(query, lstParams);
            if (check==null)
            {
                new WarningWindow(MainWindow.colorError, "DB error", "Couldnt delete student").Show();
                return;
            }





            if (!student_comboboxes_update())
            {
                return;
            }

            new WarningWindow(MainWindow.colorOK, "Success", "Successfully deleted student").Show();
        }
        string classCode = "";
        private void classInfo_click(object sender, RoutedEventArgs e)
        {
            if (courseComboC.SelectedIndex==0)
            {
                new WarningWindow(MainWindow.colorWarning, "Can't update", "Please select course first").Show();
                return;
            }
            var query = "select courses.*, instructors.number from courses join instructors on instructors.id = courses.instructor_id where courses.id=@id";
            var lstParams = new List<cmdParameterType> {
                new cmdParameterType("@id",(courseComboC.SelectedItem as ComboboxItem).Value)
            };
            var check = Database.query(query, lstParams);
            if (check==null)
            {
                new WarningWindow(MainWindow.colorError, "DB error", "Couldnt select course info").Show();
                return;
            }
            if (check.Rows.Count==0)
            {
                query = "select * from courses where id=@id";
                check = Database.query(query, lstParams);
                if (check == null)
                {
                    new WarningWindow(MainWindow.colorError, "DB error", "Couldnt select course info").Show();
                    return;
                }
                instructornameCombo.SelectedIndex = 0;

            }
            else
            {
                for (int i = 1; i < instructornameCombo.Items.Count; i++)
                {
                    var a = (instructornameCombo.Items[i] as ComboboxItem).Value.ToString();
                    var b = check.Rows[0]["instructor_id"].ToString();
                    if ((instructornameCombo.Items[i] as ComboboxItem).Value.ToString()==check.Rows[0]["instructor_id"].ToString())
                    {
                        instructornameCombo.SelectedIndex = i;
                        break;
                    }
                }

            }
            coursenameBox.Text = check.Rows[0]["name"].ToString();
            classcodeBox.Text = check.Rows[0]["code"].ToString();
            this.classCode= check.Rows[0]["code"].ToString();
            hoursCombo.SelectedIndex = (int)check.Rows[0]["start_end"];

            
            for (int i = 0; i < daysCombo.Items.Count; i++)
            {
                var a = (daysCombo.Items[i] as ComboBoxItem).Content;
                var b = check.Rows[0]["day"];
                if (check.Rows[0]["day"].ToString().ToLower()== (daysCombo.Items[i] as ComboBoxItem).Content.ToString())
                {
                    daysCombo.SelectedIndex = i;
                    break;
                }
            }
            //daysCombo.SelectedIndex


        }

        private void delete_class(object sender, RoutedEventArgs e)
        {
            if (courseComboC.SelectedIndex==0)
            {
                new WarningWindow(MainWindow.colorWarning, "Can't delete", "Please select course first").Show();
                return;
            }
            var query =

                @"delete from courses where id=@id;
                delete from notes where course_id=@id";
            var lstParams = new List<cmdParameterType> {
                new cmdParameterType("@id",(courseComboC.SelectedItem as ComboboxItem).Value)
            };
            var check = Database.query(query, lstParams);
            if (check==null)
            {
                new WarningWindow(MainWindow.colorError, "DB error", "Couldnt delete course").Show();
                return;
            }
            if (!update_faculty_department_course())
            {
                return;
            }
            new WarningWindow(MainWindow.colorOK, "Success", "Successfully deleted class \nand associated students' notes").Show();

        }

        private void update_class(object sender, RoutedEventArgs e)
        {
            var query = "";
            var lstParams = new List<cmdParameterType>();
            var check = new DataTable();
            if (courseComboC.SelectedIndex == 0)
            {
                new WarningWindow(MainWindow.colorWarning, "Can't update", "Please select course first").Show();
                return;
            }

            if (
                coursenameBox.Text=="" ||
                instructornameCombo.SelectedIndex==0 ||
                classcodeBox.Text==""
                )
            {
                new WarningWindow(MainWindow.colorWarning, "Can't update", "Please fill neccessary places").Show();
                return;
            }
            if (this.classCode!= classcodeBox.Text.ToUpper())
            {
                query = "select * from courses where code=@code";
                lstParams = new List<cmdParameterType>
                    {
                        new cmdParameterType("@code",classcodeBox.Text.ToUpper())
                    };
                check = Database.query(query, lstParams);
                if (check == null)
                {
                    new WarningWindow(MainWindow.colorError, "DB error", "Couldnt delete course").Show();
                    return;
                }
                if (check.Rows.Count != 0)
                {
                    new WarningWindow(MainWindow.colorWarning, "Can't update", "There is already a class with same code").Show();
                    return;
                }
            }
            

            query = "select * from courses where instructor_id=@instructor_id and start_end=@start_end and day=@day";
            lstParams = new List<cmdParameterType>
            {
                new cmdParameterType("@instructor_id",(instructornameCombo.SelectedItem as ComboboxItem).Value),
                new cmdParameterType("@start_end",hoursCombo.SelectedIndex+1),
                new cmdParameterType("@day",(daysCombo.Items[daysCombo.SelectedIndex] as ComboBoxItem).Content)
            };
            check = Database.query(query, lstParams);
            if (check == null)
            {
                new WarningWindow(MainWindow.colorError, "DB error", "Couldnt delete course").Show();
                return;
            }
            if (check.Rows.Count!=0)
            {
                new WarningWindow(MainWindow.colorWarning, "Can't update", "Teacher has a class at that time of the day").Show();
                return;
            }
            query = @"update courses 
                    set 
                    name=@name, instructor_id=@instructor_id, code=@code,  start_end=@start_end, day=@day where id=@id";
            lstParams.Add(new cmdParameterType("@code", classcodeBox.Text.ToUpper()));
            lstParams.Add(new cmdParameterType("@name", coursenameBox.Text));
            lstParams.Add(new cmdParameterType("@id", (courseComboC.SelectedItem as ComboboxItem).Value));
            check = Database.query(query, lstParams);
            if (check == null)
            {
                new WarningWindow(MainWindow.colorError, "DB error", "Couldnt update course").Show();
                return;
            }
            if (!update_faculty_department_course())
            {
                return;
            }
            new WarningWindow(MainWindow.colorOK, "Success", "Successfully updated").Show();

        }

        private void add_class(object sender, RoutedEventArgs e)
        {
            if (departmentComboC.SelectedIndex==0)
            {
                new WarningWindow(MainWindow.colorWarning, "Can't Add", "Please select department first").Show();
                return;
            }
            if (
                coursenameBox.Text == "" ||
                instructornameCombo.SelectedIndex == 0 ||
                classcodeBox.Text == ""
                )
            {
                new WarningWindow(MainWindow.colorWarning, "Can't Add", "Please fill neccessary places").Show();
                return;
            }
            var query = "select * from courses where instructor_id=@instructor_id and start_end=@start_end and day=@day";
            var lstParams = new List<cmdParameterType>
            {
                new cmdParameterType("@instructor_id",(instructornameCombo.SelectedItem as ComboboxItem).Value),
                new cmdParameterType("@start_end",hoursCombo.SelectedIndex+1),
                new cmdParameterType("@day",(daysCombo.Items[daysCombo.SelectedIndex] as ComboBoxItem).Content)
            };
            var check = Database.query(query, lstParams);
            if (check == null)
            {
                new WarningWindow(MainWindow.colorError, "DB error", "Couldnt delete course").Show();
                return;
            }
            if (check.Rows.Count != 0)
            {
                new WarningWindow(MainWindow.colorWarning, "Can't Add", "Teacher has a class at that time of the day").Show();
                return;
            }
            query = "select * from courses where code=@code";
            lstParams = new List<cmdParameterType>
                    {
                        new cmdParameterType("@code",classcodeBox.Text.ToUpper())
                    };
            check = Database.query(query, lstParams);
            if (check == null)
            {
                new WarningWindow(MainWindow.colorError, "DB error", "Couldnt check existing course").Show();
                return;
            }
            if (check.Rows.Count != 0)
            {
                new WarningWindow(MainWindow.colorWarning, "Can't Add", "There is already a class with same code").Show();
                return;
            }
            query = @"INSERT INTO `courses`(`code`, `name`, `instructor_id`, `department_id`, `start_end`, `day`) VALUES 
                    (@code,@name,@instructor_id,@department_id,@start_end,@day)";
            lstParams = new List<cmdParameterType>
            {
                new cmdParameterType("@code",classcodeBox.Text.ToUpper()),
                new cmdParameterType("@instructor_id",(instructornameCombo.SelectedItem as ComboboxItem).Value),
                new cmdParameterType("@department_id",(departmentComboC.SelectedItem as ComboboxItem).Value),
                new cmdParameterType("@start_end",hoursCombo.SelectedIndex+1),
                new cmdParameterType("@day",(daysCombo.SelectedItem as ComboBoxItem).Content),
                new cmdParameterType("@name",coursenameBox.Text)
            };
            check = Database.query(query, lstParams);
            if (check == null)
            {
                new WarningWindow(MainWindow.colorError, "DB error", "Couldnt insert course").Show();
                return;
            }
            if (!update_faculty_department_course())
            {
                return;
            }
            new WarningWindow(MainWindow.colorOK, "Success", "Successfully added class").Show();

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
