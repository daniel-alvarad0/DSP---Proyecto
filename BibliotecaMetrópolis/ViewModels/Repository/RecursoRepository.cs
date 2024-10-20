using BibliotecaMetrópolis;
using BibliotecaMetropolis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibliotecaMetropolis.ViewModels.Repository
{
    public class RecursoRepository
    {
        private readonly Biblioteca_Metropolis_newEntities d = new Biblioteca_Metropolis_newEntities();
        private object contexto;

        public List<RecursosMostrar> ListarRecurso()
        {
            var recursos = contexto.Recurso

            .Include("Editorial")
            .Include("Pais")
            .Include("AutoresRecursos.Autor")
            .ToList();

            return recursos.Select(recurso => new RecursosMostrar
            {
                IdRec = recurso.IdRec,
                Titulo = recurso.Titulo,
                AnnoPublic = recurso.AnnoPublic,
                Editorial = recurso.Editorial.Nombre,
                Edicion = recurso.Edicion,
                Pais = recurso.Pais.Nombre,
                AutorPrincipal = recurso.AutoresRecursos
                                    .Where(ar => ar.EsPrincipal == true)
                                    .Select(ar => ar.Autor.Nombre + " " + ar.Autor.Apellido)
                                    .ToList().FirstOrDefault(),
                AutoresSecundarios = recurso.AutoresRecursos
                                    .Where(ar => ar.EsPrincipal == false)
                                    .Select(ar => ar.Autor.Nombre + " " + ar.Autor.Apellido)
                                    .ToList(),
                PalabrasClave = recurso.PalabraBusqueda
            }).ToList();
        }

        public List<RecursosMostrar> BuscarRecursos(string tipoRecurso, string antiguedad, string autor, string editorial, string palabraClave, string pais)
        {

            var query = contexto.Recurso
                .Include("Editorial")
                .Include("Pais")
                .Include("AutoresRecursos.Autor")
                .AsQueryable();

            if (int.TryParse(autor, out int autorid))
            {
                query = query.Where(r => r.AutoresRecursos.Any(a => a.Autor.IdAutor.Equals(autorid)));
            }

            if (!string.IsNullOrEmpty(tipoRecurso))
            {
                query = query.Where(r => r.PalabraBusqueda.Contains(tipoRecurso));
            }

            if (int.TryParse(antiguedad, out int annios))
            {
                int yearLimit = DateTime.Now.Year - annios;
                query = query.Where(r => r.AnnoPublic >= yearLimit);
            }

            if (!string.IsNullOrEmpty(palabraClave))
            {
                query = query.Where(r => r.PalabraBusqueda.Contains(palabraClave));
            }

            if (int.TryParse(editorial, out int editorialid))
            {
                query = query.Where(r => r.Editorial.IdEdit.Equals(editorialid));
            }

            if (!string.IsNullOrEmpty(pais))
            {
                query = query.Where(r => r.Pais.IdPais == pais);
            }

            return query.ToList().Select(recurso => new RecursosMostrar
            {
                IdRec = recurso.IdRec,
                Titulo = recurso.Titulo,
                AnnoPublic = recurso.AnnoPublic,
                Editorial = recurso.Editorial.Nombre,
                Edicion = recurso.Edicion,
                Pais = recurso.Pais.Nombre,
                AutorPrincipal = recurso.AutoresRecursos
                                    .Where(ar => ar.EsPrincipal == true)
                                    .Select(ar => ar.Autor.Nombre + " " + ar.Autor.Apellido)
                                    .ToList().FirstOrDefault(),
                AutoresSecundarios = recurso.AutoresRecursos
                                    .Where(ar => ar.EsPrincipal == false)
                                    .Select(ar => ar.Autor.Nombre + " " + ar.Autor.Apellido)
                                    .ToList(),
                PalabrasClave = recurso.PalabraBusqueda
            }).ToList();
        }
    }
}