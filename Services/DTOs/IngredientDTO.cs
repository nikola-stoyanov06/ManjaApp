﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class IngredientDTO : BaseDTO
    {
        public double Amount { get; set; }
        public string Unit { get; set; }
    }
}
