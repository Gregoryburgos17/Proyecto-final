using Almacen02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almacen02.Controllers
{
    public class productoController : Controller
    {
        // GET: producto
        public ActionResult Index()
        {
            try
            {
                using (var db = new GestionDeAlmacenContext())
                {
                    return View(db.producto.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(producto pr)
        {

            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new GestionDeAlmacenContext())
                {
                    db.producto.Add(pr);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("error al crear", ex);
                return View();
            }


        }


        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new GestionDeAlmacenContext())
                {
                    //Cliente cl = db.Cliente.Where(a => a.codigo == id).FirstOrDefault();
                    producto cl4 = db.producto.Find(id);
                    return View(cl4);
                }

            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(producto e)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                using (var db = new GestionDeAlmacenContext())
                {
                    producto cl = db.producto.Find(e.codigo);
                    cl.fecha_de_creacion = e.fecha_de_creacion;
                    cl.fecha_vencimiento = e.fecha_vencimiento;
                    cl.nombre = e.nombre;
                    cl.Descripcion = e.Descripcion;
                    cl.UdM = e.UdM;
                    cl.Costo = e.Costo;
                    cl.Existencia = e.Existencia;
                    cl.Estado = e.Estado;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult Detalles(int id)
        {
            using (var db = new GestionDeAlmacenContext())
            {

                producto cl4 = db.producto.Find(id);
                return View(cl4);
            }

        }
        public ActionResult Eliminar(int id)
        {
            using (var db = new GestionDeAlmacenContext())
            {

                producto cl4 = db.producto.Find(id);
                db.producto.Remove(cl4);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}