using BibliotecaMetrópolis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca_Metropolis.Models.Repository
{
    public class EditorialRepository
    {
        private readonly Biblioteca_Metropolis_newEntities contexto = new Biblioteca_Metropolis_newEntities();

        public List<SelectListItem> Dropdown()
        {
            var editoriales = contexto.Editorial
                .Select(e => new SelectListItem
                {
                    Value = e.IdEdit.ToString(),
                    Text = e.Nombre
                }).OrderBy(e => e.Text)
                .ToList();
            return editoriales;
        }

        public void Registrar(string nombreEditorial)
        {
            var nuevaEditorial = new Editorial
            {
                Nombre = nombreEditorial
            };

            contexto.Editorial.Add(nuevaEditorial);
            contexto.SaveChanges();
        }

        public bool Eliminar(int id, out string errorMessage)
        {
            var editorial = contexto.Editorial.Find(id);

            if (editorial == null)
            {
                errorMessage = "La editorial no existe.";
                return false;
            }

            contexto.Editorial.Remove(editorial);
            contexto.SaveChanges();

            errorMessage = null;
            return true;
        }

        public bool Existe(string nombreEditorial)
        {
            bool existe = contexto.Editorial.Any(e => e.Nombre == nombreEditorial);
            return existe;
        }
    }
}
