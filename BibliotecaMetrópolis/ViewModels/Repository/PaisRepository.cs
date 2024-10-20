using BibliotecaMetrópolis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca_Metropolis.Models.Repository
{
    public class PaisRepository
    {
        private readonly Biblioteca_Metropolis_newEntities contexto = new Biblioteca_Metropolis_newEntities();

        public List<SelectListItem> Dropdown()
        {
            var paises = contexto.Pais
                .OrderBy(p => p.Nombre)
                .Select(p => new SelectListItem
                {
                    Value = p.IdPais.ToString(),
                    Text = p.Nombre
                }).ToList();

            return paises;
        }
    }
}
