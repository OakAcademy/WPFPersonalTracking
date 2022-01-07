using System;
using System.Collections.Generic;

#nullable disable

namespace WPFPersonalTracking.DB
{
    public partial class Salarymonth
    {
        public Salarymonth()
        {
            Salaries = new HashSet<Salary>();
        }

        public int Id { get; set; }
        public string MonthName { get; set; }

        public virtual ICollection<Salary> Salaries { get; set; }
    }
}
