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
using System.Windows.Shapes;
using WPFPersonalTracking.DB;

namespace WPFPersonalTracking
{
    /// <summary>
    /// Interaction logic for DepartmentPage.xaml
    /// </summary>
    public partial class DepartmentPage : Window
    {
        public DepartmentPage()
        {
            InitializeComponent();
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public Department department;
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtDepartmentName.Text.Trim() == "")
                MessageBox.Show("Please fill the Department Name area");
            else
            {
                using (PersonalTrackingContext db = new PersonalTrackingContext())
                {
                    if (department != null && department.Id != 0)
                    {
                        Department update = new Department();
                        update.DepartmentName = txtDepartmentName.Text;
                        update.Id = department.Id;
                        db.Departments.Update(update);
                        db.SaveChanges();
                        MessageBox.Show("Update was succesful");
                    }
                    else
                    {
                        Department dpt = new Department();
                        dpt.DepartmentName = txtDepartmentName.Text;
                        db.Departments.Add(dpt);
                        db.SaveChanges();
                        txtDepartmentName.Clear();
                        MessageBox.Show("Department was Added");
                    }

                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (department != null && department.Id != 0)
            {
                txtDepartmentName.Text = department.DepartmentName;
            }
        }
    }
}
