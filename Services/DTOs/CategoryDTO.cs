﻿using ManjaApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class CategoryDTO : BaseDTO
    {
        public string Title { get; set; }
        public virtual List<Manja> Manjas { get; set; }
    }
}
