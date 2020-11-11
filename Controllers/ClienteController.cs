using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiClientes.DAL;
using WebApiClientes.Models;

namespace WebApiClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            return new List<Cliente>();
        }

        // GET api/cliente/5
        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {
            return ClienteDAL.get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Cliente cliente)
        {
            try
            {
                ClienteDAL.insert(cliente);
            }
            catch (System.Web.Http.HttpResponseException ex)
            {
                throw ex;
            }
        }

        // PUT api/cliente/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //var clienteOnDb = ClienteDAL.update
        }

        // DELETE api/cliente/5
        [HttpDelete("{id}")]
        public void Delete(int id) => ClienteDAL.delete(id);
    }
}
