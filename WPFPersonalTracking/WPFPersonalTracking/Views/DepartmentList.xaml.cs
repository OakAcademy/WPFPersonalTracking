using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WPFPersonalTracking.Views
{
    /// <summary>
    /// Interaction logic for DepartmentList.xaml
    /// </summary>
    public partial class DepartmentList : UserControl
    {
        public DepartmentList()
        {
            InitializeComponent();
            using (PersonalTrackingContext db = new PersonalTrackingContext())
            {
                List<Department> list = db.Departments.OrderBy(x => x.DepartmentName).ToList();
                gridDepartment.ItemsSource = list;
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DepartmentPage page = new DepartmentPage();
            page.ShowDialog();
            using (PersonalTrackingContext db = new PersonalTrackingContext())
            {
                List<Department> list = db.Departments.OrderBy(x => x.DepartmentName).ToList();
                gridDepartment.ItemsSource = list;
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Department dpt = (Department)gridDepartment.SelectedItem;
            DepartmentPage page = new DepartmentPage();
            page.department = dpt;
            page.ShowDialog();
            using (PersonalTrackingContext db = new PersonalTrackingContext())
            {
                gridDepartment.ItemsSource = db.Departments.OrderBy(x => x.DepartmentName).ToList();
            }
        }
        
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Department model = (Department)gridDepartment.SelectedItem;
            if(model!=null && model.Id!=0)
            {
                if(MessageBox.Show("Are you sure to delete","Question",MessageBoxButton.YesNo
                    ,MessageBoxImage.Warning)==MessageBoxResult.Yes)
                {
                    PersonalTrackingContext db = new PersonalTrackingContext();
                    List<Position> positions = db.Positions.Where(x => x.DepartmentId == model.Id).ToList();
                    foreach (var item in positions)
                    {
                        db.Positions.Remove(item);
                    }
                    db.SaveChanges();

                    Department department = db.Departments.Find(model.Id);
                    db.Departments.Remove(department);
                    db.SaveChanges();
                    MessageBox.Show("Department was deleted");
                    gridDepartment.ItemsSource = db.Departments.ToList();
                }

            }
        }
    }
}
