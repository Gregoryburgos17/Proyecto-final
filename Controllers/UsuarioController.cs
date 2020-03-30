using Almacen02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almacen02.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            try
            {
                using (var db = new UsuarioContext())
                {
                    return View(db.AspNetUsers.ToList());
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("Error al mostrar listado de usuarios", error);
                return View();
            }
        }
        public ActionResult Role()
        {
            try
            {
                using (var db = new UsuarioContext())
                {
                    return View(db.AspNetUsers.ToList());
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("Error al mostrar listado de Roles", error);
                return View();
            }
        }
        public ActionResult Edit(string id)
        {
            try
            {

                using (var db = new UsuarioContext())
                {
                    AspNetUsers us = db.AspNetUsers.Find(id);
                    return View(us);
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("Error al editar el usuarios", error);
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AspNetUsers u)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                using (var db = new UsuarioContext())
                {
                    AspNetUsers us = db.AspNetUsers.Find(u.Id);

                    us.UserName = u.UserName;
                    us.Email = u.Email;
                    us.PhoneNumber = u.PhoneNumber;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("Error al editar el usuario", error);
                return View();
            }
        }
        public ActionResult Details(string id)
        {
            try
            {
                using (var db = new UsuarioContext())
                {
                    AspNetUsers us = db.AspNetUsers.Find(id);
                    return View(us);
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("Error al mostrar detalle de usuario", error);
                return View();
            }
        }
        public ActionResult Delete(string id)
        {
            try
            {
                using (var db = new UsuarioContext())
                {
                    AspNetUsers us = db.AspNetUsers.Find(id);
                    db.AspNetUsers.Remove(us);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("Error al eliminar usuario", error);
                return View();
            }
        }
        public ActionResult CreateRol()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRol(AspNetUserRoles r)
        {

            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new UsuarioContext())
                {
                    if (r.RoleId == "1")
                    {
                        r.Rolename = "Administrador";
                    }
                    else if (r.RoleId == "2")
                    {
                        r.Rolename = "Superior";
                    }
                    else if (r.RoleId == "3")
                    {
                        r.Rolename = "Recepcion";
                    }

                    db.AspNetUserRoles.Add(r);

                    db.SaveChanges();

                    return RedirectToAction("Role");
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("Error al agregar el rol", error);
                return View();
            }
        }
        public ActionResult EditRol(string id, string id2)
        {
            try
            {

                using (var db = new UsuarioContext())
                {
                    AspNetUserRoles rol = db.AspNetUserRoles.Find(id, id2);
                    return View(rol);
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("Error al editar el rol", error);
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRol(AspNetUserRoles r)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                using (var db = new UsuarioContext())
                {
                    AspNetUserRoles rol = db.AspNetUserRoles.Find(r.UserId, r.RoleId);

                    rol.Rolename = r.Rolename;

                    db.SaveChanges();
                    return RedirectToAction("Role");
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("Error al editar el rol", error);
                return View();
            }
        }
        public ActionResult DeleteRol(string id, string id2)
        {
            try
            {
                using (var db = new UsuarioContext())
                {
                    AspNetUserRoles us = db.AspNetUserRoles.Find(id, id2);
                    db.AspNetUserRoles.Remove(us);
                    db.SaveChanges();
                    return RedirectToAction("Role");
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("Error al eliminar usuario", error);
                return View();
            }
        }
    }
}