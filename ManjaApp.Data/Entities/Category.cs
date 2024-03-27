using ManjaApp.Data.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManjaApp.Data.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Manjas = new HashSet<Manja>();
        }
        public string Title { get; set; }
        public virtual ICollection<Manja>? Manjas { get; set; }
    }
}
