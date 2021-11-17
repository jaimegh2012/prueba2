using Prueba.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba.Admin.Controllers
{
    public class ProductoController : Controller
    {
        ProductoBL productoBL;
        CategoriaBL categoriaBL;
        List<Producto> listaProductos;

        public ProductoController()
        {
            productoBL = new ProductoBL();
            categoriaBL = new CategoriaBL();
            listaProductos = new List<Producto>();
        }

        // GET: Producto
        public ActionResult Index()
        {
            listaProductos = productoBL.obtenerProductos();
            return View(listaProductos);
        }

        public ActionResult Crear()
        {
            var producto = new Producto();

            var categorias = categoriaBL.obtenerCategorias();
            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");


            return View(producto);
        }

        [HttpPost]
        public ActionResult Crear(Producto producto)
        {
            var categorias = categoriaBL.obtenerCategorias();

            if (ModelState.IsValid)
            {
                productoBL.guardarProducto(producto);

                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");
            return View(producto);
        }

        public ActionResult Editar(int id)
        {

            var producto = productoBL.obtenerProducto(id);

            var categorias = categoriaBL.obtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", producto.CategoriaId);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(Producto producto)
        {
            var categorias = categoriaBL.obtenerCategorias();

            if (ModelState.IsValid)
            {
                productoBL.guardarProducto(producto);
                return RedirectToAction("Index");
            }


            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", producto.CategoriaId);
            return View(producto);
        }

        public ActionResult Detalle(int id)
        {
            var producto = productoBL.obtenerProducto(id);
            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var producto = productoBL.obtenerProducto(id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Producto producto)
        {
            productoBL.eliminarProducto(producto.Id);

            return RedirectToAction("Index");
        }
    }
}