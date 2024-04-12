using ManjaApp.Data.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManjaApp.Data.Entities
{
    public class Ingredient : BaseEntity
    {
        public virtual Manja? Manja { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
    }
}
