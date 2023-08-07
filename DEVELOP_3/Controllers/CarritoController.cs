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
    public class CarritoController : Controller
    {
        private ProductosEntities db = new ProductosEntities();

        public ActionResult ListarProductosEnCarrito()
        {
            var lista = (from carrito in db.Carrito
                         join pdto in db.Producto
                         on carrito.Id_Producto equals pdto.Id
                         where carrito.Id != 0
                         select new CarritoProducto
                         {
                             Id=carrito.Id,
                             Imagen = pdto.Imagen,
                             Descripcion = pdto.Descripcion,
                             Cantidad = carrito.Cantidad,
                             CostoTotal = carrito.CostoTotal,
                         }).ToList();
            return View(lista);
        }

        // GET: Carrito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrito carrito = db.Carrito.Find(id);
            if (carrito == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Producto = new SelectList(db.Producto, "Id", "Descripcion", carrito.Id_Producto);
            return View(carrito);
        }

        // POST: Carrito/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Producto,Cantidad,CostoTotal")] Carrito carrito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListarProductosEnCarrito");
            }
            ViewBag.Id_Producto = new SelectList(db.Producto, "Id", "Descripcion", carrito.Id_Producto);
            return View(carrito);
        }

        // GET: Carrito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrito carrito = db.Carrito.Find(id);
            if (carrito == null)
            {
                return HttpNotFound();
            }
            return View(carrito);
        }

        // POST: Carrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carrito carrito = db.Carrito.Find(id);
            db.Carrito.Remove(carrito);
            db.SaveChanges();
            return RedirectToAction("ListarProductosEnCarrito");
        }

       
    }
}
