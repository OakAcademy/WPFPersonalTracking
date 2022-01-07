using System;
using System.Collections.Generic;

#nullable disable

namespace WPFPersonalTracking.DB
{
    public partial class Permissonstate
    {
        public Permissonstate()
        {
            Permissions = new HashSet<Permission>();
        }

        public int Id { get; set; }
        public string PermissionState { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
