using System;
using System.Collections.Generic;

#nullable disable

namespace WPFPersonalTracking.DB
{
    public partial class Task
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? TaskStartDate { get; set; }
        public DateTime? TaskDeliveryDate { get; set; }
        public int? TaskState { get; set; }
        public string TaskTitle { get; set; }
        public string TaskContent { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Taskstate TaskStateNavigation { get; set; }
    }
}
