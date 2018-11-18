using Disqueria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disqueria.DAL
{
    public class DiscoRepository : GenericRepository<Disco>, IDiscoRepository, IDisposable
    {
        public DiscoRepository(ApplicationDbContext context) : base(context)
        { }

        public ApplicationDbContext DiscoContext
        {
            get { return context as ApplicationDbContext; }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
