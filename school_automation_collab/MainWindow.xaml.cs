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

using static School_Automation_Collab.sql.Database;

using System.Windows.Media.Animation;


namespace School_Automation_Collab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        

        public int isClickedUp = 0, isClickedIn = 1, wasClickedIn = 1, wasClickedUp = 0;
        public string colorMain = "#FF1976D3", colorInactive = "#FF569DE5", colorHover = "#FF9FBFE0", colorActive = "#FFFFFFFF";

        public MainWindow()
        {
            InitializeComponent();
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

        private void signupTab_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
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
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            // May create another window for alerts, messagebox is ugly

            if (idBox.Text=="")
            {
                MessageBox.Show("Fill ID Number!");
                return;
            }
            if (pwBox.Password == "")
            {
                MessageBox.Show("Fill Password!");
                return;
            }
            //MessageBox.Show("Waiting for db Bedirhan hurry");
            School_Automation_Collab.sql.Database connection = new School_Automation_Collab.sql.Database();



            var check=connection.select("access", "userid,pass", $"userid='{idBox.Text}' and pass='{pwBox.Password}'");
            if (check == null)
            {
                MessageBox.Show("Connection to db failed");
            }
            else if (check.Count == 0)
            {
                MessageBox.Show("Incorrect username or password");
            }
            else if (check.Count > 1)
            {
                MessageBox.Show("There are multiple entries in the db");
            }
            else
            {
                MessageBox.Show("Welcome");
            }
        }


    }
    //signup END
}
