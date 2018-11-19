using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disqueria.ViewModel
{
    public class DiscoCreacion
    {
        public DiscoVM Creacion { get; set; }
        public List<SelectListItem> Generos { get; set; }
    }
}
