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
        public string Name { get; set; }
    }
}
