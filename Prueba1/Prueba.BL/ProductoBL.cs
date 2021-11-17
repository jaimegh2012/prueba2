using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.BL
{
    public class ProductoBL
    {
        Contexto _contexto;
        List<Producto> listaProductos;

        public ProductoBL()
        {
            _contexto = new Contexto();
            listaProductos = new List<Producto>();
        }

        public Producto obtenerProducto(int id)
        {
            var producto = _contexto.Productos.Include("Categoria").FirstOrDefault(x => x.Id == id);

            return producto;
        }

        public List<Producto> obtenerProductos()
        {
            listaProductos = _contexto.Productos.Include("Categoria").ToList();

            return listaProductos;
        }


        public void guardarProducto(Producto producto)
        {
            if (producto.Id == 0)
            {
                _contexto.Productos.Add(producto);
            }
            else
            {
                var productoExistente = _contexto.Productos.Find(producto.Id);

                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.Precio = producto.Precio;
                productoExistente.CategoriaId = producto.CategoriaId;
            }

            _contexto.SaveChanges();
        }


        public void eliminarProducto(int id)
        {
            var producto = _contexto.Productos.Find(id);

            _contexto.Productos.Remove(producto);
            _contexto.SaveChanges();
        }

    }
}
