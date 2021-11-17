using Prueba.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba.Admin.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaBL categoriaBL;
        List<Categoria> listaCategorias;

        public CategoriaController()
        {
            listaCategorias = new List<Categoria>();
            categoriaBL = new CategoriaBL();
        }

        // GET: Categoria
        public ActionResult Index()
        {
            listaCategorias = categoriaBL.obtenerCategorias();
            return View(listaCategorias);
        }
    }
}