using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using GestorTareasWeb.Models;

namespace GestorTareasWeb.Controllers
{
    public class TareasController : Controller
    {
        private readonly TareaRepositorio repositorioTareas = new TareaRepositorio();

        // GET: Tareas
        public ActionResult Index()
        {
            var listaTareas = repositorioTareas.ObtenerTodasLasTareas();
            return View(listaTareas);
        }

        // GET: Tareas/Crear
        public ActionResult Crear()
        {
            var nuevaTarea = new Tarea
            {
                FechaVencimiento = DateTime.Today
            };

            return View(nuevaTarea);
        }

        // POST: Tareas/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Tarea tareaFormulario)
        {
            if (!ModelState.IsValid)
            {
                return View(tareaFormulario);
            }

            // Aquí defino la fecha de creación y marco la nueva tarea como pendiente
            tareaFormulario.FechaCreacion = DateTime.Now;
            tareaFormulario.EstaCompletada = false;

            repositorioTareas.CrearTarea(tareaFormulario);

            return RedirectToAction("Index");
        }

        // GET: Tareas/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tarea = repositorioTareas.ObtenerTareaPorId(id.Value);

            if (tarea == null)
            {
                return HttpNotFound();
            }

            return View(tarea);
        }

        // POST: Tareas/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Tarea tareaFormulario)
        {
            if (!ModelState.IsValid)
            {
                return View(tareaFormulario);
            }

            repositorioTareas.ActualizarTarea(tareaFormulario);

            return RedirectToAction("Index");
        }

        // GET: Tareas/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tarea = repositorioTareas.ObtenerTareaPorId(id.Value);

            if (tarea == null)
            {
                return HttpNotFound();
            }

            return View(tarea);
        }

        // POST: Tareas/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int id)
        {
            repositorioTareas.EliminarTarea(id);

            return RedirectToAction("Index");
        }

        // GET: Tareas/CambiarEstado/5
        public ActionResult CambiarEstado(int id)
        {
            // Aquí solo llamo al repositorio para invertir el estado y regreso al listado
            repositorioTareas.CambiarEstadoTarea(id);

            return RedirectToAction("Index");
        }
    }
}