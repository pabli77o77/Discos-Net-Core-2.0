using Disqueria.Models;
using Disqueria.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IEnumerable<DiscoVM> Grilla()
        {
            return DiscoContext.Discos.Select
                (
                    x => new DiscoVM
                    {
                        DiscoID = x.DiscoID,
                        Titulo = x.Titulo,
                        //GeneroID = x.GeneroID,
                        //Genero = x.Genero.ToString(),
                        DiscograficaID = x.DiscograficaID,
                        Discografica = x.Discografica.ToString(),
                        ArtistaID = x.ArtistaID,
                        Artista = x.Artista.ToString()
                    }
                ).ToList();
        }

        public DiscoEdicion GetEdicion(int? id)
        {
            DiscoEdicion vm = new DiscoEdicion();
            if (id != null)
            {
                vm.Edicion = DiscoContext.Discos
                    .Where(x => x.DiscoID == id)
                    .Select(d => new DiscoVM
                    {
                        DiscoID = d.DiscoID,
                        Titulo = d.Titulo,
                        Artista = d.Artista.ToString(),
                        ArtistaID = d.ArtistaID,
                        //Genero = d.Genero.ToString(),
                        //GeneroID = d.GeneroID,
                        DiscograficaID = d.DiscograficaID,
                        Discografica = d.Discografica.ToString()
                    }).FirstOrDefault();

                vm.Generos = DiscoContext.Generos.Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.GeneroID.ToString()
                }).ToList();

                vm.Artistas = DiscoContext.Artistas.Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.ArtistaID.ToString()
                }).ToList();

                vm.Discograficas = DiscoContext.Discograficas.Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.DiscograficaID.ToString()
                }).ToList();
            }
            return vm;
        }

        public bool AddDisco(DiscoEdicion vm)
        {
            Disco model = new Disco()
            {
                Titulo = vm.Edicion.Titulo,
                ArtistaID = vm.Edicion.ArtistaID,
                //GeneroID = vm.Edicion.GeneroID,
                DiscograficaID = vm.Edicion.DiscograficaID
            };
            return this.Add(model);
        }

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
