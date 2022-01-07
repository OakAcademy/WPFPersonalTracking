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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFPersonalTracking.DB;
using WPFPersonalTracking.ViewModels;

namespace WPFPersonalTracking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lblWindowName.Content = "Task List";
            DataContext = new TaskViewModel();


        }

        private void btnDepartment_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Department List";
            DataContext = new DepartmentViewModel();
        }

        private void btnPosition_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Position List";
            DataContext = new PositionViewModel();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            
            if(!UserStatic.isAdmin)
            {
                PersonalTrackingContext db = new PersonalTrackingContext();
                Employee employee = db.Employees.Find(UserStatic.EmployeeId);
                EmployeeDetailModel model = new EmployeeDetailModel();
                model.Adress = employee.Adress;
                model.BirthDay = (DateTime)employee.Birthday;
                model.DepartmentId = employee.DepartmentId;
                model.Id = employee.Id;
                model.ImagePath = employee.ImagePath;
                model.isAdmin = employee.IsAdmin;
                model.Name = employee.Name;
                model.Password = employee.Password;
                model.PositionId = employee.PositionId;
                model.Salary = employee.Salary;
                model.Surname = employee.Surname;
                model.UserNo = employee.UserNo;
                EmployeePage page = new EmployeePage();
                page.model = model;
                page.ShowDialog();
            }
            else
            {
                lblWindowName.Content = "Employee List";
                DataContext = new EmployeeViewModel();
            }
        }

        private void btnTask_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Task List";
            DataContext = new TaskViewModel();
        }

        private void btnSalary_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Salary List";
            DataContext = new SalaryViewModel();
        }

        private void btnPermission_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Permission List";
            DataContext = new PermissionViewModel();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PersonalMainWindow_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PersonalMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if(!UserStatic.isAdmin)
            {
                stackDepartment.Visibility = Visibility.Hidden;
                stackPosition.Visibility = Visibility.Hidden;
                stacklogoff.SetValue(Grid.RowProperty, 5);
                stackexit.SetValue(Grid.RowProperty, 6);

            }
        }
    }
}
