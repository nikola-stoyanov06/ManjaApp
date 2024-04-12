using ManjaApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManjaApp.Data.Repositories.Abstractions
{
    public interface IManjaRepository : ICrudRepository<Manja>
    {
        public Task UpdateManja(Manja manja, Category category);
    }
}
