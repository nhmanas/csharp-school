using System;
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
        public string colorMain = "#FF1976D3", colorInactive = "#FF569DE5", colorHover = "#FF9FBFE0", colorActive = "#FFFFFFFF", colorError = "#FF5D0052", colorWarning = "#FFFFBE00", colorOK = "#FF61B600";

        

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
            rememberCheck.Visibility = Visibility.Visible;
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
            rememberCheck.Visibility = Visibility.Hidden;
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
            //MessageBox.Show("Waiting for db Bedirhan hurry");
            Database connection = new Database();
            List<cmdParameterType> lstParams = new List<cmdParameterType> {
                new cmdParameterType("@user_id", idBox.Text.Trim()),
                new cmdParameterType("@pass", pwBox.Password) };

            var query = "select * from access where user_id=@user_id and pass=@pass";

            var check=connection.query(query,lstParams);
            if (check == null)
            {
                messageHandle(colorError, "Check your connection");
                return;
            }
            else if (check.Rows.Count == 0)
            {
                messageHandle(colorWarning, "Incorrect username or password");
            }
            else if (check.Rows.Count > 1)
            {
                messageHandle(colorError, "There are multiple entries in the db");
            }
            else
            {
                messageHandle(colorOK, "Logging in...");
                MessageBox.Show("Welcome");
                Window1 win1 = new Window1();
                win1.Show();
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

            var connection = new Database();
            List<cmdParameterType> lstParams = new List<cmdParameterType> {
                new cmdParameterType("@user_id", n) };

            var query = "select * from access where user_id=@user_id";

            var check=connection.query(query, lstParams);

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


            query = $"INSERT INTO `access`(`name`, `user_id`, `pass`, `type`) VALUES (@name,@user_id,@pass,{type})";
            lstParams = new List<cmdParameterType>
            {
                new cmdParameterType("@name",signupBox_name.Text.Trim()),
                new cmdParameterType("@user_id",n),
                new cmdParameterType("@pass",pwBox_signup.Password)
            };
            check = connection.query(query, lstParams);
            if (check == null)
            {
                messageHandle(colorError, "Check your connection");
                return;
            }
            MessageBox.Show("Signup complete please login");

            signinTab_MouseLeftButtonUp(new object(), a);
        }
    }

    
    //signup END
}
