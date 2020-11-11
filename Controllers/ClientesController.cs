using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Clauses.ExpressionVisitors;
using System;
using System.Collections.Generic;
using WebApiClientes.Models;
using WebApiClientes.Repositories;

namespace WebApiClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        /// <summary>o
        /// GET - listar clientes (Ex: api/clientes)
        /// </summary>
        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            try
            {
                return ClienteRepository.list();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>o
        /// GET - buscar cliente especifico pelo id (Ex: api/clientes/5)
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {
            try
            {
                return ClienteRepository.get(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>o
        /// POST - cadastrar cliente utilizando como exemplo o conteudo do body do request (Ex: api/clientes)
        /// </summary>
        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                ClienteRepository.insert(cliente);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>o
        /// PUT - atualizar cliente especifico pelo id c/ request no body (Ex: api/clientes/5)
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cliente cliente)
        {
            try
            {
                Cliente clienteOnDb = ClienteRepository.get(id);

                if (clienteOnDb is null) 
                    return NotFound();

                ClienteRepository.update(id, cliente);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>o
        /// DELETE - deletar cliente pelo Id (Ex: api/cliente/5)
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                ClienteRepository.delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
