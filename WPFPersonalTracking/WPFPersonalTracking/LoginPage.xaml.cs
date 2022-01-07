using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFPersonalTracking.DB;

namespace WPFPersonalTracking
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
            List<Taskstate> list = db.Taskstates.ToList(); 
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        PersonalTrackingContext db = new PersonalTrackingContext();
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserNo.Text.Trim() == "" || txtPassword.Text.Trim() == "")
                MessageBox.Show("Please fill the Userno and password area");
            else
            {
                Employee employee = db.Employees.FirstOrDefault(x => x.UserNo == Convert.ToInt32(txtUserNo.Text) &&
                  x.Password.Equals(txtPassword.Text));
                if (employee != null && employee.Id != 0)
                {
                    this.Visibility = Visibility.Collapsed;
                    MainWindow main = new MainWindow();
                    UserStatic.EmployeeId = employee.Id;
                    UserStatic.isAdmin = employee.IsAdmin;
                    UserStatic.Name = employee.Name;
                    UserStatic.Surname = employee.Surname;
                    UserStatic.UserNo = employee.UserNo;
                    main.ShowDialog();
                    txtPassword.Clear();
                    txtUserNo.Clear();
                    this.Visibility = Visibility.Visible;
                }
                else
                    MessageBox.Show("Please make sure that your passwrod and userno is true");
            }
        }

        private void txtUserNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
