﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class ManjaDTO : BaseDTO
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Instructions { get; set; }
        public string Picture { get; set; }
        public CategoryDTO Category { get; set; }
        public IdentityUser User  { get; set; }
        public string UserId { get; set; }
        public List<CommentDTO>? Comments { get; set; }
    }
}
