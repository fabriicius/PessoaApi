using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
//using System.Web.Http.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PessoaApi.Repository.Dominio;
using PessoaApi.Repository.Models;

namespace PessoaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PessoasController : ControllerBase
    {
        public PessoasController(IPessoaDominio pessoaDominio)
        {
            _pessoaDominio = pessoaDominio;
        }

        private IPessoaDominio _pessoaDominio;

        [HttpGet("Consultar/{numero}")]
        [AllowAnonymous]
        public IActionResult Consultar(string numero)
        {
            try
            {
                return Ok(_pessoaDominio.Consultar(numero));
            }
            catch(Exception e)
            {
                return BadRequest();
            }
            
        }

        [HttpGet("Consultar")]
        [AllowAnonymous]
        public IActionResult Consultar()
        {
            try
            {
                return Ok(_pessoaDominio.Consultar());
            }
           catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost("Atualizar")]
        [AllowAnonymous]
        public IActionResult Atualizar([FromBody]Pessoa pessoa)
        {
            try
            {
                _pessoaDominio.Atualizar(pessoa);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
           
        }

        [HttpPost("Cadastrar")]
        [AllowAnonymous]
        public IActionResult Cadastrar([FromBody] Pessoa pessoa)
        {
            try
            {
                _pessoaDominio.Cadastrar(pessoa);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

        [HttpPost("Deletar/{numero}")]
        [AllowAnonymous]
        public IActionResult Deletar(string numero)
        {
            try
            {
                _pessoaDominio.Deletar(numero);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }
    }
}
