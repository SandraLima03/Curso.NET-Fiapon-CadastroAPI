using CadastroAPI.Models;
using CadastroAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CadastroAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : Controller
    { 
        private readonly PessoaRepository pessoaRepository;

        public PessoaController()
        {
            pessoaRepository = new PessoaRepository();
        }

        [HttpGet]
        public IActionResult Consultar()
        {
            try
            {
                var listaPessoa = pessoaRepository.Listar();
                return Ok(listaPessoa);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        [Route("Consultar/{id}")]
        public ActionResult Consultar(int id)
        {
            try
            {
                var pessoa = pessoaRepository.Consultar(id);
                if (pessoa.IdPessoa != 0)
                {
                    return Ok(pessoa);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public ActionResult Cadastrar(Models.Pessoa pessoa)
        {
            try
            {
                pessoaRepository.Inserir(pessoa);
                return Ok(pessoa);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        public ActionResult Editar(Models.Pessoa pessoa)
        {
            try
            {
                pessoaRepository.Alterar(pessoa);
                return Ok(pessoa);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public ActionResult Excluir(int id)
        {

            try
            {
                pessoaRepository.Excluir(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }
    }
}
