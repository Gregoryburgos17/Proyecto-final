using Almacen02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almacen02.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            try
            {
                using (var db = new GestionDeAlmacenContext())
                {
                    return View(db.clientes.ToList());
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
        public ActionResult Agregar(clientes cl)
        {

            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new GestionDeAlmacenContext())
                {
                    db.clientes.Add(cl);
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
                    //Cliente cl = db.Cliente.Where(a => a.codigo == id).FirstOrDefault(); otra forma de hacerlo 
                    clientes cl = db.clientes.Find(id);
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
        public ActionResult Editar(clientes e)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                using (var db = new GestionDeAlmacenContext())
                {
                    clientes cl = db.clientes.Find(e.codigo);
                    cl.nombre = e.nombre;
                    cl.apellido = e.apellido;
                    cl.telefono = e.telefono;
                    cl.direccion = e.direccion;
                    cl.correo = e.correo;
                    cl.tipo_de_cliente = e.tipo_de_cliente;
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

                clientes cl4 = db.clientes.Find(id);
                return View(cl4);
            }

        }
        public ActionResult Eliminar(int id)
        {
            using (var db = new GestionDeAlmacenContext())
            {

                clientes cl4 = db.clientes.Find(id);
                db.clientes.Remove(cl4);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}