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
using WPFPersonalTracking.ViewModels;

namespace WPFPersonalTracking
{
    /// <summary>
    /// Interaction logic for PositionPage.xaml
    /// </summary>
    public partial class PositionPage : Window
    {
        public PositionPage()
        {
            InitializeComponent();
        }
        PersonalTrackingContext db = new PersonalTrackingContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var list = db.Departments.ToList().OrderBy(x => x.DepartmentName);
            cmbDepartment.ItemsSource = list;
            cmbDepartment.DisplayMemberPath = "DepartmentName";
            cmbDepartment.SelectedValuePath = "Id";
            cmbDepartment.SelectedIndex = -1;
            if (model != null && model.Id != 0)
            {
                cmbDepartment.SelectedValue = model.DepartmentId;
                txtPositionname.Text = model.PositionName;
            }

        }
        public PositionModel model;
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cmbDepartment.SelectedIndex == -1 || txtPositionname.Text.Trim() == "")
                MessageBox.Show("Please fill all areas");
            else
            {
                if (model != null && model.Id != 0)
                {
                    Position pst = new Position();
                    pst.DepartmentId = (int)cmbDepartment.SelectedValue;
                    pst.Id = model.Id;
                    pst.PositionName = txtPositionname.Text;
                    db.Positions.Update(pst);
                    db.SaveChanges();
                    MessageBox.Show("Position was Updated");
                }
                else
                {
                    Position position = new Position();
                    position.PositionName = txtPositionname.Text;
                    position.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                    db.Positions.Add(position);
                    db.SaveChanges();
                    cmbDepartment.SelectedIndex = -1;
                    txtPositionname.Clear();
                    MessageBox.Show("Position was Added");
                }

            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
