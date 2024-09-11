using JDVA_10092024.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JDVA_10092024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {

        static List<Alumno> alumnos = new List<Alumno>();

        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return alumnos;
        }

        [HttpGet("{id}")]
        public Alumno Get(int id)
        {
            var alum = alumnos.FirstOrDefault(a => a.Id == id);
            return alum;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Alumno alumno)
        {
            alumnos.Add(alumno);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult  Put(int id, [FromBody]  Alumno alumno)
        {
            var existingAlum = alumnos.FirstOrDefault(a => a.Id == id);
            if (existingAlum != null)
            {
                existingAlum.Nombre = alumno.Nombre;
                existingAlum.Apellido = alumno.Apellido;
                existingAlum.Codigo = alumno.Codigo;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingAlum = alumnos.FirstOrDefault(a => a.Id == id);
            if (existingAlum != null)
            {
                alumnos.Remove(existingAlum);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
