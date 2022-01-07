using System;
using System.Collections.Generic;

#nullable disable

namespace WPFPersonalTracking.DB
{
    public partial class Taskstate
    {
        public Taskstate()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string NameState { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
