﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using School_Automation_Collab.sql;

using System.Windows.Media.Animation;


namespace School_Automation_Collab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int isClickedUp = 0, isClickedIn = 1, wasClickedIn = 1, wasClickedUp = 0;
        public static string colorMain = "#FF1976D3", colorInactive = "#FF569DE5", colorHover = "#FF9FBFE0", colorActive = "#FFFFFFFF", colorError = "#FF5D0052", colorWarning = "#FFFFBE00", colorOK = "#FF61B600";

        

        public MainWindow()
        {
            
            InitializeComponent();
            warningBox.Visibility = Visibility.Hidden;
            warningLabel.Visibility = Visibility.Hidden;
        }

        //signin START

        private void signinTab_MouseEnter(object sender, MouseEventArgs e)
        {
            if (wasClickedIn == 0)
            {
                signinTab.Effect = null;
                if (isClickedUp == 1)
                {
                    signinTab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorHover));
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student win1 = new Student();
            win1.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Teacher win2 = new Teacher();
            win2.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Admin win3 = new Admin();
            win3.Show();
        }

        private void signinTab_MouseLeave(object sender, MouseEventArgs e)
        {
            if (wasClickedIn == 0)
            {
                signinTab.Effect = new BlurEffect();
                signinTab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorInactive));
            }
            if (wasClickedIn == 1)
            {
                signinTab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorActive));
            }
        }

        private void signinTab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            a = e;
            signinTab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorActive));
            loginButton.Visibility = Visibility.Visible;
            signupTab.Effect = new BlurEffect();
            if (isClickedUp == 1)
            {
                isClickedUp = 0;
                wasClickedUp = 0;
                signupTab.Effect = new BlurEffect();
                signupTab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorInactive));
                wasClickedIn = 1;
                isClickedIn = 1;
            }
            signupIdBox.Visibility = Visibility.Hidden;
            idLabel_signup.Visibility = Visibility.Hidden;
            signupLabel_name.Visibility = Visibility.Hidden;
            signupBox_name.Visibility = Visibility.Hidden;
            pwBox_signup.Visibility = Visibility.Hidden;
            pwLabel_signup.Visibility = Visibility.Hidden;
            authLevelCombo_signup.Visibility = Visibility.Hidden;
            authLevelLabel_signup.Visibility = Visibility.Hidden;


            idLabel_signin.Visibility = Visibility.Visible;
            idBox.Visibility = Visibility.Visible;
            pwBox.Visibility = Visibility.Visible;
            pwLabel_signin.Visibility = Visibility.Visible;

            warningBox.Visibility = Visibility.Hidden;
            warningLabel.Visibility = Visibility.Hidden;
        }

        //signin END

        //signup START

        private void signupTab_MouseEnter(object sender, MouseEventArgs e)
        {
            if (wasClickedUp == 0)
            {
                signupTab.Effect = null;
                signupTab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorHover));
            }
        }

        private void signupTab_MouseLeave(object sender, MouseEventArgs e)
        {
            if (wasClickedUp == 0)
            {
                signupTab.Effect = new BlurEffect();
                signupTab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorInactive));
            }
            if (wasClickedUp == 1)
            {
                signupTab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorActive));
            }
        }
        private MouseButtonEventArgs a;
        private void signupTab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            a = e;
            signupTab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorActive));
            loginButton.Visibility = Visibility.Hidden;
            if (isClickedIn == 1)
            {
                isClickedIn = 0;
                wasClickedIn = 0;
                signinTab.Effect = new BlurEffect();
                signinTab.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorInactive));
                wasClickedUp = 1;
                isClickedUp = 1;
            }
            signupIdBox.Visibility = Visibility.Visible;
            idLabel_signup.Visibility = Visibility.Visible;
            signupLabel_name.Visibility = Visibility.Visible;
            signupBox_name.Visibility = Visibility.Visible;
            pwBox_signup.Visibility = Visibility.Visible;
            pwLabel_signup.Visibility = Visibility.Visible;
            authLevelCombo_signup.Visibility = Visibility.Visible;
            authLevelLabel_signup.Visibility = Visibility.Visible;


            idLabel_signin.Visibility = Visibility.Hidden;
            idBox.Visibility = Visibility.Hidden;
            pwBox.Visibility = Visibility.Hidden;
            pwLabel_signin.Visibility = Visibility.Hidden;

            warningBox.Visibility = Visibility.Hidden;
            warningLabel.Visibility = Visibility.Hidden;
        }
        private void messageHandle(string color, string message)
        {
            warningBox.Visibility = Visibility.Visible;
            warningBox.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
            warningLabel.Visibility = Visibility.Visible;
            warningLabel.Content = message;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (idBox.Text.Trim() == "" || pwBox.Password == "")
            {
                messageHandle(colorWarning, "Please fill the required fields");
                return;
            }
            int n;
            bool isNumeric = int.TryParse(idBox.Text.Trim(), out n);
            if (!isNumeric)
            {
                messageHandle(colorWarning, "ID field must be numeric");
                return;
            }
            
            List<cmdParameterType> lstParams = new List<cmdParameterType> {
                new cmdParameterType("@user_id", idBox.Text.Trim()),
                new cmdParameterType("@pass", pwBox.Password) };

            var query = "select * from access where user_id=@user_id and pass=@pass";

            var check=Database.query(query,lstParams);
            if (check == null)
            {
                messageHandle(colorError, "Check your connection");
                return;
            }
            else if (check.Rows.Count == 0)
            {
                messageHandle(colorWarning, "Incorrect username or password");
                return;
            }
            else if (check.Rows.Count > 1)
            {
                messageHandle(colorError, "There are multiple entries in the db");
                return;
            }
            var access = check.Rows[0];
            if (check.Rows[0]["type"].ToString()=="2")
            {


                query = "select * from students where number=@user_id";
                var check2 = Database.query(query, lstParams);
                if (check2==null)
                {
                    messageHandle(colorError, "???");
                    return;
                }

                messageHandle(colorOK, "Logging in...");
                //Student(string name, string surname, int id, string faculty, string department, int year)
                var students = check2.Rows[0];



                //query = "select access.*, departments.name as 'department_name', faculties.name as 'faculty_name' from access join departments on departments.id=access.department_id join faculties on faculties.id=access.faculty_id where user_id=@user_id and pass=@pass";
                //check = Database.query(query);
                new WarningWindow(colorOK, "OK", "Log in successfull",
                    new Student(
                        access["name"].ToString(),
                        access["surname"].ToString(),
                        (int)access["user_id"],
                        access["faculty_id"].ToString(),
                        access["department_id"].ToString(),
                        students["year"].ToString()
                        )
                    ).Show();
                this.Close();
            }
            else if (check.Rows[0]["type"].ToString() == "1")
            {
                //teacher
                query = "select * from instructors where number=@number";
                lstParams=new List<cmdParameterType> { new cmdParameterType("@number", check.Rows[0]["user_id"]) };
                check = Database.query(query, lstParams);
                if (check==null)
                {
                    messageHandle(colorError, "Check your connection");
                    return;
                }
                else if (check.Rows.Count == 0)
                {
                    messageHandle(colorWarning, "Incorrect username or password");
                    return;
                }
                else if (check.Rows.Count > 1)
                {
                    messageHandle(colorError, "There are multiple entries in the instructors db");
                    return;
                }
                if (check.Rows[0]["status"].ToString()=="0")
                {
                    new WarningWindow(colorWarning, "Waiting Approve","Your Teacher account must be \napproved by admin to continue").Show();
                    return;
                }


                new WarningWindow(colorOK, "OK", "Log in successfull", 
                    new Teacher(
                        access["name"].ToString(),
                        access["surname"].ToString(),
                        access["user_id"].ToString(),
                        access["faculty_id"].ToString(),
                        access["department_id"].ToString()
                        )
                    ).Show();
                this.Close();
            }
            else if(check.Rows[0]["type"].ToString() == "0")
            {
                //admin
                new WarningWindow(colorOK, "OK", "Log in successfull", 
                    new Admin(
                        "admin",
                        access["name"].ToString(),
                        access["surname"].ToString(),
                        access["user_id"].ToString()
                        )
                    ).Show();
                this.Close();
            }
                
            
            //this.Hide();
            //Window1 win1 = new Window1();
            //win1.Show();
        }
        private void signupButton_Click(object sender, RoutedEventArgs e)
        {
            if (signupIdBox.Text.Trim() == "" || pwBox_signup.Password == "" || signupBox_name.Text.Trim()=="")
            {
                messageHandle(colorWarning, "Please fill the required fields");
                return;
            }
            int n;
            bool isNumeric = int.TryParse(signupIdBox.Text.Trim(), out n);
            if (!isNumeric)
            {
                messageHandle(colorWarning, "ID field must be numeric");
                return;
            }

            List<cmdParameterType> lstParams = new List<cmdParameterType> {
                new cmdParameterType("@user_id", n) };

            var query = "select * from access where user_id=@user_id";

            var check=Database.query(query, lstParams);

            if (check == null)
            {
                messageHandle(colorError, "Check your connection");
                return;
            }
            else if(check.Rows.Count==1)
            {
                messageHandle(colorWarning, "There is a user with same user id");
                return;
            }
            else if (check.Rows.Count > 1)
            {
                messageHandle(colorError, "There are multiple entries in the db");
                return;
            }
            int type = 2 - authLevelCombo_signup.SelectedIndex;


            query = $"INSERT INTO `access`(`name`, `user_id`, `pass`, `type`, `surname`) VALUES (@name,@user_id,@pass,{type},'')";
            lstParams = new List<cmdParameterType>
            {
                new cmdParameterType("@name",signupBox_name.Text.Trim()),
                new cmdParameterType("@user_id",n),
                new cmdParameterType("@pass",pwBox_signup.Password)
            };
            check = Database.query(query, lstParams);
            if (check == null)
            {
                messageHandle(colorError, "Check your connection");
                return;
            }
            if (authLevelCombo_signup.SelectedIndex==0) //if student
            {
                query = $"insert into students (number,year,updated_at) values (@user_id,{DateTime.Now.Year},current_timestamp())";
                check = Database.query(query, lstParams);
                if (check==null)
                {
                    messageHandle(colorError, "Check your connection");
                    return;
                }
            }
            else
            {
                query = $"insert into instructors (number,updated_at) values (@user_id,current_timestamp())";
                check = Database.query(query, lstParams);
                if (check == null)
                {
                    messageHandle(colorError, "Check your connection");
                    return;
                }
            }
            
            
            new WarningWindow(colorOK, "Success", "Signup Complete, Please Login").Show();

            signinTab_MouseLeftButtonUp(new object(), a);
        }
    }

    
    //signup END
}
