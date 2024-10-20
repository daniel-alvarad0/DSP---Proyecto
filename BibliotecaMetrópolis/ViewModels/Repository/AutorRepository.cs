using BibliotecaMetrópolis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca_Metropolis.Models.Repository
{
    public class AutorRepository
    {
        private readonly Biblioteca_Metropolis_newEntities contexto = new Biblioteca_Metropolis_newEntities();

        public List<SelectListItem> Dropdown()
        {
            var autores = contexto.Autor
               .Select(a => new SelectListItem
               {
                   Value = a.IdAutor.ToString(),
                   Text = a.Nombre + " " + a.Apellido
               }).ToList();

            return autores;
        }

        public void Registrar(string nombre, string apellido)
        {
            var nuevoAutor = new Autor
            {
                Nombre = nombre,
                Apellido = apellido
            };

            // Agregar el nuevo autor a la base de datos
            contexto.Autor.Add(nuevoAutor);
            contexto.SaveChanges();
        }

        public bool Eliminar(int id, out string errorMessage)
        {
            var autor = contexto.Autor.Find(id);

            if (autor == null)
            {
                errorMessage = "La editorial no existe.";
                return false;
            }

            contexto.Autor.Remove(autor);
            contexto.SaveChanges();

            errorMessage = null;
            return true;
        }

        public bool Existe(string nombre, string apellido)
        {
            bool existe = contexto.Autor.Any(a => a.Nombre == nombre && a.Apellido == apellido);
            return existe;
        }
    }
}
