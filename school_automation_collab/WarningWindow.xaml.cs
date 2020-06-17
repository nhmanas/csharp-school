using System;
using System.Collections.Generic;
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
    /// Interaction logic for WarningWindow.xaml
    /// </summary>
    public partial class WarningWindow : Window
    {
        Window a;
        public WarningWindow()
        {
            wwHeader.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(MainWindow.colorError));
            wwHeader.Content = "Connection error";
            wwContent.Content = "There are errors with db";
            this.a = new MainWindow();
        }
            public WarningWindow(string headerBackground, string Title, string Content, Window a=null)
        {

            InitializeComponent();
            wwHeader.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(headerBackground));
            wwHeader.Content = Title;
            wwContent.Content = Content;
            this.a = a;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (a != null)
            {
                a.Show();
            }
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (a!=null)
            {
                a.Show();
            }

        }
    }
}
