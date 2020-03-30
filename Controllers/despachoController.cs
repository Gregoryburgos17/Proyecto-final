using Almacen02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almacen02.Controllers
{
    public class despachoController : Controller
    {
        // GET: despacho
        public ActionResult Index()
        {
            try
            {
                using (var db = new GestionDeAlmacenContext())
                {
                    return View(db.Despacho.ToList());
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
        public ActionResult Agregar(Despacho d)
        {

            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new GestionDeAlmacenContext())
                {
                    db.Despacho.Add(d);
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
                    Despacho cl = db.Despacho.Find(id);
                    return View(cl);
                }

            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Despacho e)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                using (var db = new GestionDeAlmacenContext())
                {
                    Despacho cl = db.Despacho.Find(e.id);
                    cl.fecha = e.fecha;
                    cl.tipo_de_acciom = e.tipo_de_acciom;
                    cl.producto = e.producto;
                    cl.clientes = e.clientes;
                    cl.contactos = e.contactos;
                    cl.Detalle_de_productos = e.Detalle_de_productos;
                    cl.cant_producto = e.cant_producto;

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

                Despacho cl4 = db.Despacho.Find(id);
                return View(cl4);
            }

        }
        public ActionResult Eliminar(int id)
        {
            using (var db = new GestionDeAlmacenContext())
            {

                Despacho cl = db.Despacho.Find(id);
                db.Despacho.Remove(cl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}