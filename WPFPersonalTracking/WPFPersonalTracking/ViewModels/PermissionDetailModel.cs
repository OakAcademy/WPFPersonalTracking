using System;
using System.Collections.Generic;
using System.Text;

namespace WPFPersonalTracking.ViewModels
{
   public class PermissionDetailModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int UserNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StateName { get; set; }
        public string Explanation { get; set; }
        public int PermissionState { get; set; }
        public int DayAmount { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
    }
}
