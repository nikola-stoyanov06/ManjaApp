﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManjaApp.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public string ProfilePicURL { get; set; }
        public ICollection<Manja>? Manjas { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}