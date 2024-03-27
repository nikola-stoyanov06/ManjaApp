using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManjaApp.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Manjas = new HashSet<Manja>();
            Comments = new HashSet<Comment>();
        }
        public string ProfilePicURL { get; set; }
        public virtual ICollection<Manja>? Manjas { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
