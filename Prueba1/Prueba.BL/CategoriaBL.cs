using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.BL
{
    public class CategoriaBL
    {
        Contexto _contexto;
        List<Categoria> listaCategorias;

        public CategoriaBL()
        {
            _contexto = new Contexto();
            listaCategorias = new List<Categoria>();
        }

        public Categoria obtenerCategoria(int id)
        {
            var categoria = _contexto.Categorias.FirstOrDefault(x => x.Id == id);
            return categoria;
        }

        public List<Categoria> obtenerCategorias()
        {
            listaCategorias = _contexto.Categorias.ToList();
            return listaCategorias;
        }

        public void guardarCategoria(Categoria categoria)
        {
            if (categoria.Id == 0)
            {
                _contexto.Categorias.Add(categoria);
            }
            else
            {
                var categoriaExistente = _contexto.Categorias.Find(categoria.Id);

                categoriaExistente.Descripcion = categoria.Descripcion;
            }

            _contexto.SaveChanges();
        }

        public void eliminarCategoria(int id)
        {
            var categoria = _contexto.Categorias.Find(id);

            _contexto.Categorias.Remove(categoria);
            _contexto.SaveChanges();
        }
    }
}
