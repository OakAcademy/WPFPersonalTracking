using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WPFPersonalTracking.Views
{
    /// <summary>
    /// Interaction logic for TaskList.xaml
    /// </summary>
    public partial class TaskList : UserControl
    {
        public TaskList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            TaskPage page = new TaskPage();
            page.ShowDialog();
            FillDataGrid();

        }

        PersonalTrackingContext db = new PersonalTrackingContext();
        List<TaskDetailModel> tasklist = new List<TaskDetailModel>();
        List<TaskDetailModel> searchlist = new List<TaskDetailModel>();
        List<Position> positions = new List<Position>();

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();

            if(!UserStatic.isAdmin)
            {
                btnAdd.Visibility = Visibility.Hidden;
                btnUpdate.Visibility = Visibility.Hidden;
                btnDelete.Visibility = Visibility.Hidden;
                btnApprove.SetValue(Grid.ColumnProperty, 1);
                btnApprove.Content = "Delivery";


            }
        }
        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            if(model!=null && model.Id!=0)
            {


                if (UserStatic.isAdmin && model.TaskState == Definitions.TaskStates.OnEmployee)
                    MessageBox.Show("Before approve a task,Task must be Delivered");
                else if (UserStatic.isAdmin && model.TaskState == Definitions.TaskStates.Approved)
                    MessageBox.Show("This task is Already approved");
                else if (!UserStatic.isAdmin && model.TaskState == Definitions.TaskStates.Delivered)
                    MessageBox.Show("This Task is already delivered");
                else if (!UserStatic.isAdmin && model.TaskState == Definitions.TaskStates.Approved)
                    MessageBox.Show("This task is already approved");
                else
                {

                    Task task = db.Tasks.Find(model.Id);
                    if (UserStatic.isAdmin)
                        task.TaskState = Definitions.TaskStates.Approved;
                    else
                        task.TaskState = Definitions.TaskStates.Delivered;
                    db.SaveChanges();
                    MessageBox.Show("Task was Updated");
                    FillDataGrid();
                }
            }
        }
        void FillDataGrid()
        {
            tasklist = db.Tasks.Include(x => x.TaskStateNavigation).Include(x => x.Employee)
                .ThenInclude(x => x.Department).ThenInclude(x => x.Positions).Select(x => new TaskDetailModel()
                {
                    Id = x.Id,
                    EmployeeId = (int)x.EmployeeId,
                    Name = x.Employee.Name,
                    StateName = x.TaskStateNavigation.NameState,
                    Surname = x.Employee.Surname,
                    TaskContent = x.TaskContent,
                    TaskDeliveryDate = x.TaskDeliveryDate,
                    TaskStartDate = (DateTime)x.TaskStartDate,
                    TaskState = (int)x.TaskState,
                    TaskTitle = x.TaskTitle,
                    UserNo = x.Employee.UserNo,
                    DepartmentId = x.Employee.DepartmentId,
                    PositionId = x.Employee.PositionId
                }).ToList();
           if(!UserStatic.isAdmin)
            {
                tasklist = tasklist.Where(x => x.EmployeeId == UserStatic.EmployeeId).ToList();
                txtUserNo.IsEnabled = false;
                txtName.IsEnabled = false;
                txtSurname.IsEnabled = false;
                cmbDepartment.IsEnabled = false;
                cmbPosition.IsEnabled = false;
            }
            gridTask.ItemsSource = tasklist;
            searchlist = tasklist;
            cmbDepartment.ItemsSource = db.Departments.ToList();
            cmbDepartment.DisplayMemberPath = "DepartmentName";
            cmbDepartment.SelectedValuePath = "Id";
            cmbDepartment.SelectedIndex = -1;
            positions = db.Positions.ToList();
            cmbPosition.ItemsSource = positions;
            cmbPosition.DisplayMemberPath = "PositionName";
            cmbPosition.SelectedValuePath = "Id";
            cmbPosition.SelectedIndex = -1;
            List<Taskstate> taskstates = db.Taskstates.ToList();
            cmbState.ItemsSource = taskstates;
            cmbState.DisplayMemberPath = "NameState";
            cmbState.SelectedValuePath = "Id";
            cmbState.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<TaskDetailModel> search = searchlist;
            if (txtUserNo.Text.Trim() != "")
                search = search.Where(x => x.UserNo == Convert.ToInt32(txtUserNo.Text)).ToList();
            if (txtName.Text.Trim() != "")
                search = search.Where(x => x.Name.Contains(txtName.Text)).ToList();
            if (txtSurname.Text.Trim() != "")
                search = search.Where(x => x.Surname.Contains(txtSurname.Text)).ToList();
            if (cmbDepartment.SelectedIndex != -1)
                search = search.Where(x => x.DepartmentId == Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            if (cmbPosition.SelectedIndex != -1)
                search = search.Where(x => x.PositionId == Convert.ToInt32(cmbPosition.SelectedValue)).ToList();
            if (cmbState.SelectedIndex != -1)
                search = search.Where(x => x.TaskState == Convert.ToInt32(cmbState.SelectedValue)).ToList();
            if (rbStart.IsChecked == true)
                search = search.Where(x => x.TaskStartDate > dpStart.SelectedDate && x.TaskStartDate < dpDelivery.SelectedDate).ToList();
            if (rbDelivery.IsChecked == true)
                search = search.Where(x => x.TaskDeliveryDate > dpStart.SelectedDate && x.TaskDeliveryDate < dpDelivery.SelectedDate).ToList();
            gridTask.ItemsSource = search;


        }

        private void cmbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
            if (cmbDepartment.SelectedIndex != -1)
            {
                cmbPosition.ItemsSource = positions.Where(x => x.DepartmentId == DepartmentId).ToList();
                cmbPosition.DisplayMemberPath = "PositionName";
                cmbPosition.SelectedValuePath = "Id";
                cmbPosition.SelectedIndex = -1;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtUserNo.Clear();
            txtName.Clear();
            txtSurname.Clear();
            dpDelivery.SelectedDate = DateTime.Today;
            dpStart.SelectedDate = DateTime.Today;
            cmbDepartment.SelectedIndex = -1;
            cmbState.SelectedIndex = -1;
            cmbPosition.ItemsSource = positions;
            cmbPosition.SelectedIndex = -1;
            rbDelivery.IsChecked = false;
            rbStart.IsChecked = false;
            gridTask.ItemsSource = tasklist;
        }
        TaskDetailModel model = new TaskDetailModel();
        private void gridTask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            model = (TaskDetailModel)gridTask.SelectedItem;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            TaskPage page = new TaskPage();
            page.model = model;
            page.ShowDialog();
            FillDataGrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Are you sure to delete","Question",MessageBoxButton.YesNo
                ,MessageBoxImage.Warning)==MessageBoxResult.Yes)
            {
                if(model.Id!=0)
                {
                    TaskDetailModel taskmodel = (TaskDetailModel)gridTask.SelectedItem;
                    Task task = db.Tasks.First(x => x.Id == taskmodel.Id);
                    db.Tasks.Remove(task);
                    db.SaveChanges();
                    MessageBox.Show("Task was Deleted");
                    FillDataGrid();
                }
            }
        }

        

        
    }
}
