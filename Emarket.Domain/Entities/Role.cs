using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emarket.Domain.Entities
{
    public class Role : IdentityRole<int>
    {
        public string Name { get; set; }=string.Empty;
        public virtual ICollection<User>? Users { get; set; } = new List<User>();
        public virtual ICollection<Permission>? Permissions { get; set; } = new List<Permission>();
    }
}
