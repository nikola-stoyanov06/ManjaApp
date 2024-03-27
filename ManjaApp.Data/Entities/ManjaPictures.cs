using ManjaApp.Data.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManjaApp.Data.Entities
{
    public class ManjaPictures : BaseEntity 
    {
        public Manja? Manja { get; set; }
        public string PictureURL { get; set; }
    }
}
