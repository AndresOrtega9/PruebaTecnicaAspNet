using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DEVELOP_3.Models;
namespace DEVELOP_3.Controllers
{
    public class InformeController : Controller
    {
        ProductosEntities _contexto = new ProductosEntities();
        // GET: Informe
        public ActionResult Index()
        {
            var lista = _contexto.Producto.OrderByDescending(c => c.Costo).Take(3).ToList();
            return View(lista);
        }
    }
}