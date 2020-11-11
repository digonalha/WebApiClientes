using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApiClientes.Models;
using WebApiClientes.Repositories;

namespace WebApiClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        /// <summary>
        /// GET - listar endereco (Ex: api/clientes)
        /// </summary>
        [HttpGet]
        public ActionResult<List<Endereco>> Get()
        {
            try
            {
                return EnderecoRepository.list();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>o
        /// GET - buscar endereco especifico pelo id (Ex: api/enderecos/5)
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Endereco> Get(int id)
        {
            try
            {
                return EnderecoRepository.get(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// POST - cadastrar enderecos utilizando como exemplo o conteudo do body do request (Ex: api/enderecos)
        /// </summary>
        [HttpPost]
        public ActionResult Post([FromBody] Endereco endereco)
        {
            try
            {
                EnderecoRepository.insert(endereco);
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
        public ActionResult Put(int id, [FromBody] Endereco endereco)
        {
            try
            {
                Endereco enderecoOnDb = EnderecoRepository.get(id);

                if (enderecoOnDb is null)
                    return NotFound();

                EnderecoRepository.update(id, endereco);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// DELETE - deleta enderecos pelo Id (Ex: api/enderecos/5)
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                EnderecoRepository.delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}
