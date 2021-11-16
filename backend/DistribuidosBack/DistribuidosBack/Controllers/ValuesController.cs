using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;//libreria cor
using System.Text.Json;
using DistribuidosBack.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DistribuidosBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]//libreria cors
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public String  Get()
        {
            Conexion conexion = new Conexion();
            Usuarios u = new Usuarios("", "",0);
            String json = u.listar(conexion);
            return json;
        }





        // GET api/<ValuesController>/5
        [HttpGet("{cedula}")]
        public string Get(string cedula)
        {
            Conexion conexion = new Conexion();
            Usuarios u = new Usuarios(cedula, "", 0);
            String mensaje = u.listar(conexion);
            return mensaje;
        }


        
        [HttpGet("login/{cedula}/{nombre}")]
        public string Get(string cedula,string nombre)
        {
            Conexion conexion = new Conexion();
            Usuarios u = new Usuarios(cedula, nombre, 0);
            String mensaje = u.login(conexion);
            return mensaje;
        }






        // POST api/<ValuesController>
        [HttpPost]
        public string Post([FromBody] JsonElement datos)
        {
            String cedula = datos.GetProperty("cedula").ToString();
            String nombre = datos.GetProperty("nombre").ToString();
            int edad = datos.GetProperty("edad").GetInt32();

            Conexion conexion = new Conexion();
            Usuarios u = new Usuarios(cedula, nombre, edad);
            String mensaje = u.ingresarU(conexion);
            return mensaje;

        }



        // PUT api/<ValuesController>/5
        [HttpPut("{i}")]
        public void Put(string id, [FromBody] JsonElement datos)
        {

            String cedula = datos.GetProperty("cedula").ToString();
            String nombre = datos.GetProperty("nombre").ToString();
            int edad = datos.GetProperty("edad").GetInt32();
            Conexion conexion = new Conexion();
            Usuarios u = new Usuarios(cedula, nombre, edad);
            String mensaje = u.modificar(conexion);
        }



        // DELETE api/<ValuesController>/5
        [HttpDelete("{cedula}")]
        public String Delete(String cedula)
        {
            Conexion conexion = new Conexion();
            Usuarios u = new Usuarios(cedula, "", 0);
            String mensaje = u.eliminar(conexion);
            return mensaje;
        }


    }
}
