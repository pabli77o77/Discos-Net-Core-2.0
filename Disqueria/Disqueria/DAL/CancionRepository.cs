using Disqueria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disqueria.DAL
{
    public class CancionRepository : GenericRepository<Cancion>, ICancionRepository, IDisposable
    {
        public CancionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext CancionContext
        {
            get { return context as ApplicationDbContext; }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
