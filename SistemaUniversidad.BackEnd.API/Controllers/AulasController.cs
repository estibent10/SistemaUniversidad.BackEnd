using Microsoft.AspNetCore.Mvc;
using SistemaUniversidad.BackEnd.API.Dtos;
using SistemaUniversidad.BackEnd.API.Models;
using SistemaUniversidad.BackEnd.API.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaUniversidad.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulasController : ControllerBase
    {
        private readonly IAulasService ServicioDeAulas;
        public AulasController(IAulasService AulasService)
        {
            ServicioDeAulas = AulasService;            
        }
        // GET: api/<AulasController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AulasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AulasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AulasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AulaDto AulaDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Aula AulaPorActualizar = new();

                    AulaPorActualizar.NumeroDeAula = AulaDTO.NumeroDeAula;
                    AulaPorActualizar.NombreDeAula = AulaDTO.NombreDeAula;
                    AulaPorActualizar.ModificadoPor = "diazgs";

                    ServicioDeAulas.Actualizar(AulaPorActualizar);

                    return Ok();
                }
                else
                {
                    string ErroreEnElModelo = ObtenerErroresDeModeloInvalido();

                    return BadRequest(ErroreEnElModelo);
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        // DELETE api/<AulasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private string ObtenerErroresDeModeloInvalido()
        {

            var ListaDeErroresEnModelo = ModelState.Keys.Where(i => ModelState[i].Errors.Count > 0)
                                                     .Select(k => ModelState[k].Errors.First().ErrorMessage);

            string ListaDeErroresEnModeloConcatenados = string.Join("\n", ListaDeErroresEnModelo);

            return ListaDeErroresEnModeloConcatenados;
        }
    }
}
