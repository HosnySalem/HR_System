﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.DAL.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string   Name { get; set; }

        public ICollection<AppUser> Users { get; set; } = new HashSet<AppUser>();
        public ICollection<PermissionsDB> Permissions { get; set; } = new List<PermissionsDB>();

    }
}
