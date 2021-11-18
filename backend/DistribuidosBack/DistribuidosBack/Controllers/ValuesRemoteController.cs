using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DistribuidosBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesRemoteController : ControllerBase
    {
        // GET: api/<ValuesRemoteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesRemoteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



        // Método para consumir el GET desde otra api, en este caso PHP. 
        [HttpGet("webservice/{codigo}/{nombre}")]
        public String Get(String codigo, String nombre)
        {

            using (var httpClient = new HttpClient())
            {
                string contentType = "application/json";
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                var userAgent = "d-fens HttpClient";
                httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);

                var response = httpClient.GetStringAsync(new Uri("http://localhost/backendDistribuidos/webServiceDistribuidos.php")).Result;

                return response;
                
            }
        }



        // POST api/<ValuesRemoteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesRemoteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesRemoteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
