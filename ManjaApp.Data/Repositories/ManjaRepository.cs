using ManjaApp.Data.Data;
using ManjaApp.Data.Entities;
using ManjaApp.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManjaApp.Data.Repositories
{
    public class ManjaRepository : CrudRepository<Manja>, IManjaRepository
    {
        private readonly ApplicationDbContext _context;
        public ManjaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task UpdateManja(Manja manja, Category category)
        {
            _context.ChangeTracker.LazyLoadingEnabled = true;
            _context.Manjas.Attach(manja);

            if (!_context.Entry(manja).Reference(r => r.Category).IsLoaded)
            {
                await _context.Entry(manja).Reference(r => r.Category).LoadAsync();
            }
            manja.Category = category;

            await UpdateAsync(manja);
        }
    }
}
