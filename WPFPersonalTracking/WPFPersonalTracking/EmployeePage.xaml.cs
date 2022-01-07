
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using WPFPersonalTracking.ViewModels;

namespace WPFPersonalTracking
{
    /// <summary>
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Window
    {
        public EmployeePage()
        {
            InitializeComponent();
        }
        PersonalTrackingContext db = new PersonalTrackingContext();
        List<Position> positions = new List<Position>();
        public EmployeeDetailModel model;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbDepartment.ItemsSource = db.Departments.ToList();
            cmbDepartment.DisplayMemberPath = "DepartmentName";
            cmbDepartment.SelectedValuePath = "Id";
            cmbDepartment.SelectedIndex = -1;
            positions = db.Positions.ToList();
            cmbPosition.ItemsSource = positions;
            cmbPosition.DisplayMemberPath = "PositionName";
            cmbPosition.SelectedValuePath = "Id";
            cmbPosition.SelectedIndex = -1;
            if (model != null && model.Id != 0)
            {
                cmbDepartment.SelectedValue = model.DepartmentId;
                cmbPosition.SelectedValue = model.PositionId;
                txtUserNo.Text = model.UserNo.ToString();
                txtPassword.Text = model.Password;
                txtName.Text = model.Name;
                txtSurname.Text = model.Surname;
                txtSalary.Text = model.Salary.ToString();
                txtAdress.AppendText(model.Adress);
                picker1.SelectedDate = model.BirthDay;
                chisAdmin.IsChecked = model.isAdmin;
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(@"Images/" + model.ImagePath,UriKind.RelativeOrAbsolute);
                image.EndInit();
                EmployeeImage.Source = image;
            }

            if(!UserStatic.isAdmin)
            {
                chisAdmin.IsEnabled = false;
                txtUserNo.IsEnabled = false;
                txtSalary.IsEnabled = false;
                cmbDepartment.IsEnabled = false;
                cmbPosition.IsEnabled = false;
            }

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
        OpenFileDialog dialog = new OpenFileDialog();
        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {
            if (dialog.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(dialog.FileName);
                image.EndInit();
                EmployeeImage.Source = image;
                txtImage.Text = dialog.FileName;
            }
        }

        private void txtUserNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserNo.Text.Trim() == "" || txtPassword.Text.Trim() == "" || txtName.Text.Trim() == ""
               || txtSurname.Text.Trim() == "" || txtSalary.Text.Trim() == "" || cmbDepartment.SelectedIndex == -1
               || cmbPosition.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill the necessary areas");
            }
            else
            {
                if (model != null && model.Id != 0)
                {
                    Employee employee = db.Employees.Find(model.Id);
                    List<Employee> employeelist = db.Employees.Where(x => x.UserNo == Convert.ToInt32(txtUserNo.Text) &&
                      x.Id != employee.Id).ToList();
                    if (employeelist.Count > 0)
                    {
                        MessageBox.Show("This User no is already used by Another Employee");
                    }
                    else
                    {


                        if (txtImage.Text.Trim() != "")
                        {
                            if (File.Exists(@"Images//" + employee.ImagePath))
                            {
                                File.Delete(@"Images//" + employee.ImagePath);
                                string filename = "";
                                string Unique = Guid.NewGuid().ToString();
                                filename += Unique + System.IO.Path.GetFileName(txtImage.Text);
                                File.Copy(txtImage.Text, @"Images//" + filename);
                                employee.ImagePath = filename;
                            }


                        }
                        employee.UserNo = Convert.ToInt32(txtUserNo.Text);
                        employee.Password = txtPassword.Text;
                        employee.IsAdmin = (bool)chisAdmin.IsChecked;
                        TextRange adres = new TextRange(txtAdress.Document.ContentStart, txtAdress.Document.ContentEnd);
                        employee.Adress = adres.Text;
                        employee.Birthday = picker1.SelectedDate;
                        employee.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                        employee.PositionId = Convert.ToInt32(cmbPosition.SelectedValue);
                        employee.Name = txtName.Text;
                        employee.Salary = Convert.ToInt32(txtSalary.Text);
                        employee.Surname = txtSurname.Text;
                        db.SaveChanges();
                        MessageBox.Show("Employee Was Updated");
                    }
                }
                else
                {
                    var Uniquelist = db.Employees.Where(x => x.UserNo == Convert.ToInt32(txtUserNo.Text)).ToList();
                    if (Uniquelist.Count > 0)
                    {
                        MessageBox.Show("This User No is Already used by another employee");
                    }
                    else
                    {

                        Employee employee = new Employee();
                        employee.UserNo = Convert.ToInt32(txtUserNo.Text);
                        employee.Password = txtPassword.Text;
                        employee.Name = txtName.Text;
                        employee.Surname = txtSurname.Text;
                        employee.Salary = Convert.ToInt32(txtSalary.Text);
                        employee.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                        employee.PositionId = Convert.ToInt32(cmbPosition.SelectedValue);
                        TextRange text = new TextRange(txtAdress.Document.ContentStart, txtAdress.Document.ContentEnd);
                        employee.Adress = text.Text;
                        employee.Birthday = picker1.SelectedDate;
                        employee.IsAdmin = (bool)chisAdmin.IsChecked;
                        string filename = "";
                        string Unique = Guid.NewGuid().ToString();
                        filename += Unique + dialog.SafeFileName;
                        employee.ImagePath = filename;
                        db.Employees.Add(employee);
                        db.SaveChanges();
                        File.Copy(txtImage.Text, @"Images//" + filename);
                        MessageBox.Show("Employee was Added");
                        txtUserNo.Clear();
                        txtPassword.Clear();
                        txtName.Clear();
                        txtSurname.Clear();
                        txtSalary.Clear();
                        picker1.SelectedDate = DateTime.Today;
                        cmbDepartment.SelectedIndex = -1;
                        cmbPosition.ItemsSource = positions;
                        cmbPosition.SelectedIndex = -1; txtAdress.Document.Blocks.Clear();
                        chisAdmin.IsChecked = false;
                        EmployeeImage.Source = new BitmapImage();
                        txtImage.Clear();
                    }

                }




            }
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            bool isUnique = false;
            var Uniquelist = db.Employees.Where(x => x.UserNo == Convert.ToInt32(txtUserNo.Text)).ToList();
            if (Uniquelist.Count > 0)
            {
                MessageBox.Show("This User No is Already used by another employee");
            }
            else
            {
                MessageBox.Show("This user no is avaliable");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
