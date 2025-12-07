using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GestorTareasWeb.Models;

namespace GestorTareasWeb.Controllers
{
    public class TareasApiController : ApiController
    {
        private readonly TareaRepositorio repositorioTareas = new TareaRepositorio();

        // GET api/tareasapi
        public IEnumerable<Tarea> Get()
        {
            // Aquí devuelvo todas las tareas como JSON
            return repositorioTareas.ObtenerTodasLasTareas();
        }

        // GET api/tareasapi/5
        public IHttpActionResult Get(int id)
        {
            var tarea = repositorioTareas.ObtenerTareaPorId(id);

            if (tarea == null)
            {
                return NotFound();
            }

            return Ok(tarea);
        }

        // POST api/tareasapi
        public IHttpActionResult Post([FromBody] Tarea tareaNueva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Cuando creo desde el API también defino la fecha de creación aquí.
            tareaNueva.FechaCreacion = System.DateTime.Now;

            repositorioTareas.CrearTarea(tareaNueva);

            return StatusCode(HttpStatusCode.Created);
        }

        // PUT api/tareasapi/5
        public IHttpActionResult Put(int id, [FromBody] Tarea tareaEditar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tareaExistente = repositorioTareas.ObtenerTareaPorId(id);

            if (tareaExistente == null)
            {
                return NotFound();
            }

            tareaEditar.IdTarea = id;

            repositorioTareas.ActualizarTarea(tareaEditar);

            return Ok();
        }

        // DELETE api/tareasapi/5
        public IHttpActionResult Delete(int id)
        {
            var tareaExistente = repositorioTareas.ObtenerTareaPorId(id);

            if (tareaExistente == null)
            {
                return NotFound();
            }

            repositorioTareas.EliminarTarea(id);

            return Ok();
        }
    }
}