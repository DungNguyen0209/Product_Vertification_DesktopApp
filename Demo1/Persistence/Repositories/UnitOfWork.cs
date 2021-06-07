using ProductVertificationDesktopApp.Persistence.Contexts;
using ProductVertificationDesktopApp.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Persistence.Repositories
{
    class UnitOfWork: IunitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void DetachChange()
        {
            var changedEntriesCopy = _context.ChangeTracker.Entries()
                .Where(e => e.State == (System.Data.Entity.EntityState)EntityState.Added ||
                            e.State == (System.Data.Entity.EntityState)EntityState.Modified ||
                            e.State == (System.Data.Entity.EntityState)EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = (System.Data.Entity.EntityState)EntityState.Detached;

        }
    }
}
