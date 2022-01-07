using System;
using System.Collections.Generic;

#nullable disable

namespace WPFPersonalTracking.DB
{
    public partial class Employee
    {
        public Employee()
        {
            Permissions = new HashSet<Permission>();
            Salaries = new HashSet<Salary>();
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public int UserNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImagePath { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int Salary { get; set; }
        public DateTime? Birthday { get; set; }
        public string Adress { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }

        public virtual Department Department { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
