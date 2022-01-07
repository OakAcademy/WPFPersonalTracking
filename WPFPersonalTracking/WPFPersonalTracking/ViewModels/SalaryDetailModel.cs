using System;
using System.Collections.Generic;
using System.Text;

namespace WPFPersonalTracking.ViewModels
{
    public class SalaryDetailModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int UserNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Amount { get; set; }
        public string MonthName { get; set; }
        public int MonthId { get; set; }
        public int Year { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }

    }
}
