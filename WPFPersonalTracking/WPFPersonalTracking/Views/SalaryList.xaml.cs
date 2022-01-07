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
    /// Interaction logic for SalaryList.xaml
    /// </summary>
    public partial class SalaryList : UserControl
    {
        public SalaryList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            SalaryPage page = new SalaryPage();
            page.ShowDialog();
            FillDataGrid();
        }
        PersonalTrackingContext db = new PersonalTrackingContext();
        List<SalaryDetailModel> salaries = new List<SalaryDetailModel>();
        List<Position> positions = new List<Position>();
        void FillDataGrid()
        {
            salaries = db.Salaries.Include(x => x.Employee).Include(x => x.MonthNavigation).Select(x=>new SalaryDetailModel()
            { 
            UserNo=x.Employee.UserNo,
            Name=x.Employee.Name,
            Amount=x.Amount,
            EmployeeId=x.EmployeeId,
            Id=x.Id,
            MonthId=x.Month,
            MonthName=x.MonthNavigation.MonthName,
            Surname=x.Employee.Surname,
            Year=x.Year,
            DepartmentId=x.Employee.DepartmentId,
            PositionId=x.Employee.PositionId
            }).OrderByDescending(x=>x.Year).OrderByDescending(x=>x.MonthId).ToList();
            if(!UserStatic.isAdmin)
            {
                btnAdd.Visibility = Visibility.Hidden;
                btnDelete.Visibility = Visibility.Hidden;
                btnUpdate.Visibility = Visibility.Hidden;
                salaries = salaries.Where(x => x.EmployeeId == UserStatic.EmployeeId).ToList();
                txtUserNo.IsEnabled = false;
                txtName.IsEnabled = false;
                txtSurname.IsEnabled = false;
                cmbDepartment.IsEnabled = false;
                cmbPosition.IsEnabled = false;
            }
            gridSalary.ItemsSource = salaries;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
            cmbDepartment.ItemsSource = db.Departments.ToList();
            cmbDepartment.DisplayMemberPath = "DepartmentName";
            cmbDepartment.SelectedValuePath = "Id";
            cmbDepartment.SelectedIndex = -1;
            positions = db.Positions.ToList();
            cmbPosition.ItemsSource = positions;
            cmbPosition.DisplayMemberPath = "PositionName";
            cmbPosition.SelectedValuePath = "Id";
            cmbPosition.SelectedIndex = -1;
            List<Salarymonth> months = db.Salarymonths.ToList();
            cmbMonth.ItemsSource = months;
            cmbMonth.DisplayMemberPath = "MonthName";
            cmbMonth.SelectedValuePath = "Id";
            cmbMonth.SelectedIndex = -1;
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

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<SalaryDetailModel> search = salaries;
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
            if (txtYear.Text.Trim() != "")
                search = search.Where(x => x.Year == Convert.ToInt32(txtYear.Text)).ToList();
            if (cmbMonth.SelectedIndex != -1)
                search = search.Where(x => x.MonthId == Convert.ToInt32(cmbMonth.SelectedValue)).ToList();
            if(txtSalary.Text.Trim()!="")
            {
                if (rbMore.IsChecked == true)
                    search = search.Where(x => x.Amount > Convert.ToInt32(txtSalary.Text)).ToList();
                else if (rbLess.IsChecked == true)
                    search = search.Where(x => x.Amount < Convert.ToInt32(txtSalary.Text)).ToList();
                else
                    search = search.Where(x => x.Amount == Convert.ToInt32(txtSalary.Text)).ToList();

            }
            gridSalary.ItemsSource = search;

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtUserNo.Clear();
            txtName.Clear();
            txtSurname.Clear();
            txtYear.Clear();
            txtSalary.Clear();
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.ItemsSource = positions;
            cmbPosition.SelectedIndex = -1;
            cmbMonth.SelectedIndex = -1;
            rbEquals.IsChecked = false;
            rbMore.IsChecked = false;
            rbLess.IsChecked = false;
            gridSalary.ItemsSource = salaries;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            SalaryPage page = new SalaryPage();
            page.model = model;
            page.ShowDialog();
            FillDataGrid();
        }
        SalaryDetailModel model = new SalaryDetailModel();
        private void gridSalary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            model = (SalaryDetailModel)gridSalary.SelectedItem;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Are you sure to delete","Question",MessageBoxButton.YesNo
                ,MessageBoxImage.Warning)==MessageBoxResult.Yes)
            {
                if(model.Id!=0)
                {
                    SalaryDetailModel salarymodel = (SalaryDetailModel)gridSalary.SelectedItem;
                    Salary salary = db.Salaries.Find(salarymodel.Id);
                    db.Salaries.Remove(salary);
                    db.SaveChanges();
                    MessageBox.Show("Salary was deleted");
                    FillDataGrid();
                }
            }
        }
    }
}
