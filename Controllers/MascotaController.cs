using MascotasAPI;
using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers;

[ApiController]
[Route("[controller]")]
public class MascotaController : ControllerBase
{
    private static List<Mascotas> listmascotas = new List<Mascotas>
    {
        new Perro {Id = 1, Nombre = "Firulais", Edad = 5, Raza = "Husky"},
        new Gato {Id = 2, Nombre= "Luna", Edad = 3, Color = "Naranja"},
        new Perro {Id = 3, Nombre ="Rocky", Edad = 8, Raza = "Golden Retriver"},
        new Gato { Id = 4, Nombre= "Michi", Edad = 10, Color = "Negro"}
    };

    [HttpGet]
    public IActionResult get()
    {
        return Ok(listmascotas);
    }

    [HttpGet("{id}")]
    public IActionResult GetbyID(int id)
    {
        foreach (Mascotas m in listmascotas)
        {
            if(m.Id == id)
            {
                return Ok(m);
            }
        }
        return NotFound("mascota no encontrada");

    }

    [HttpPost("Perro")]
    public IActionResult Create([FromBody] Perro nuevoperro)
    {
        nuevoperro.Id = listmascotas.Count + 1;

        listmascotas.Add(nuevoperro);

        return StatusCode(201,"nuevo perro creado");
    }

    [HttpPost("Gato")]
    public IActionResult Create([FromBody] Gato nuevoGato)
    {
        nuevoGato.Id = listmascotas.Count + 1;

        listmascotas.Add(nuevoGato);

        return StatusCode(201,"nuevo gato creado");
    }

    [HttpPut("{id}")]
    public IActionResult update(int id, [FromBody] Mascotas actualizar)
    {
        foreach (Mascotas m in listmascotas)
        {
            if(m.Id == id)
            {
                m.Nombre = actualizar.Nombre;
                m.Edad = actualizar.Edad;
                return Ok("mascota actualizada");
            }
        }
        return NotFound("mascota no encontrada");
    }

    [HttpDelete ("{id}")]
    public IActionResult Delete(int id)
    {
        foreach(Mascotas m in listmascotas)
        {
            if (m.Id == id)
            {
                listmascotas.Remove(m);
                return Ok ("Mascotas eliminada");
            }
        }
        return NotFound("mascota no encontrada");
    }

    [HttpGet("{edad}")]
    public IActionResult MayoresA(int edad)
    {
        List<Mascotas> resultado = new List<Mascotas>();

        foreach (Mascotas m in listmascotas)
        {
            if(m.Edad > edad)
            {
                resultado.Add(m);
            }
        }
        return Ok(resultado);
    }

    [HttpGet ("{tipo}")]
    public IActionResult Tipo(string tipo)
    {
        List <Mascotas> resultado = new List<Mascotas>();
        
        foreach(Mascotas m in listmascotas)
        {
            if(tipo.ToLower() == "perro" && m is Perro)
            {
                resultado.Add(m);
            }

            if(tipo.ToLower() == "gato" && m is Gato)
            {
                resultado.Add(m);
            }
        }

        return Ok(resultado);
    }
}