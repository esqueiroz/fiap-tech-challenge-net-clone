using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Domain.Interfaces;
using TechChallenge.UseCase.ContatoUseCase.Adicionar;
using TechChallenge.UseCase.ContatoUseCase.Alterar;
using TechChallenge.UseCase.ContatoUseCase.Obter;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IAdicionarContatoUseCase _adicionarContatoUseCase;
        private readonly IAlterarContatoUseCase _alterarContatoUseCase;
        private readonly IObterContatoUseCase _obterContatoUseCase;
        private readonly IListarContatoUseCase _listarContatoUseCase;

        public ContatoController(IAdicionarContatoUseCase adicionarContatoUseCase, 
            IAlterarContatoUseCase alterarContatoUseCase, 
            IObterContatoUseCase obterContatoUseCase,
            IListarContatoUseCase listarContatoUseCase)
        {
            _adicionarContatoUseCase = adicionarContatoUseCase;
            _alterarContatoUseCase = alterarContatoUseCase;
            _obterContatoUseCase = obterContatoUseCase;
            _listarContatoUseCase= listarContatoUseCase;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            try
            {
                return Ok(_obterContatoUseCase.ObterPorId(new ObterContatoDto
                {
                    Id = id
                }));               
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_listarContatoUseCase.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]        
        public IActionResult Post(AdicionarContatoDto adicionarContatoDto)
        {
            try
            {
                return Ok(_adicionarContatoUseCase.Adicionar(adicionarContatoDto));
            }
            catch (Exception e )
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(AlterarContatoDto alterarContatoDto)
        {
            try
            {
                _alterarContatoUseCase.Alterar(alterarContatoDto);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);                
            }
        }
    }
}
