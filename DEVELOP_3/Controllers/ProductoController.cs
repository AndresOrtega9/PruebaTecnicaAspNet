using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DEVELOP_3.Models;
using DEVELOP_3.Models.ViewModels;

namespace DEVELOP_3.Controllers
{
    public class ProductoController : Controller
    {
        private ProductosEntities db = new ProductosEntities();

        public List<Producto> ObtenerProductos()
        {
            return db.Producto.ToList();
        }
    
        public ActionResult Catalogo()
        {
            List<Producto> producto = ObtenerProductos();
            return View(producto);
        }

        [HttpPost]
        public ActionResult Catalogo(List<Carrito> productosSeleccionados)
        {
            foreach (var item in productosSeleccionados)
            {
                if (item.Cantidad != null)
                {
                    item.Id_Producto = item.Id;
                    item.Cantidad = item.Cantidad;
                    item.CostoTotal = item.Costo * item.Cantidad;
                    db.Carrito.Add(item);
                }
            }
            db.SaveChanges();
            return RedirectToAction("ListarProductosEnCarrito","Carrito");
        }
    }
}
